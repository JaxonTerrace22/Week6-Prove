using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Week6_Prove // Ensure this matches the folder name
{
    public static class MapsTester
    {
        // Returns a dictionary with a count for each degree found in column 4 of the file
        public static Dictionary<string, int> SummarizeDegrees(string filename)
        {
            var degrees = new Dictionary<string, int>();

            // Reads file line by line
            foreach (var line in File.ReadLines(filename))
            {
                // Splits line by commas into fields
                var fields = line.Split(',');

                // Ensures there are at least 4 columns since degree is in column 4 in test file
                if (fields.Length >= 4)
                {
                    // Trims whitespace from the degree field
                    string degree = fields[3].Trim();

                    // If degree exists, increment its count, else add with count 1
                    if (degrees.ContainsKey(degree))
                    {
                        degrees[degree]++;
                    }
                    else
                    {
                        degrees[degree] = 1;
                    }
                }
            }

            return degrees;
        }

        // Returns true if word1 and word2 are anagrams ignoring spaces and letter case
        private static bool IsAnagram(string word1, string word2)
        {
            string normalized1 = new string(word1.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();
            string normalized2 = new string(word2.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();

            if (normalized1.Length != normalized2.Length)
            {
                return false;
            }

            Dictionary<char, int> letterCounts = new Dictionary<char, int>();
            foreach (char c in normalized1)
            {
                if (letterCounts.ContainsKey(c))
                {
                    letterCounts[c]++;
                }
                else
                {
                    letterCounts[c] = 1;
                }
            }

            foreach (char c in normalized2)
            {
                if (!letterCounts.ContainsKey(c))
                {
                    return false;
                }
                letterCounts[c]--;
                if (letterCounts[c] < 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static void Run()
        {
            Console.WriteLine("Testing summarize degrees function");
            try
            {
                // Dynamically set the path to census.txt relative to the project directory
                string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "census.txt");

                if (!File.Exists(filename))
                {
                    Console.WriteLine("File not found: " + filename);
                }
                else
                {
                    var degreeSummary = SummarizeDegrees(filename);
                    foreach (var kvp in degreeSummary)
                    {
                        Console.WriteLine("Degree: " + kvp.Key + " Count: " + kvp.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }

            Console.WriteLine("\nTesting is anagram function");
            var testCases = new List<Tuple<string, string, bool>>()
            {
                new Tuple<string, string, bool>("cat", "act", true),
                new Tuple<string, string, bool>("dog", "god", true),
                new Tuple<string, string, bool>("dog", "good", false),
                new Tuple<string, string, bool>("Ab", "Ba", true),
                new Tuple<string, string, bool>("conversation", "voices rant on", true),
                new Tuple<string, string, bool>("hello", "bellow", false)
            };

            foreach (var test in testCases)
            {
                bool result = IsAnagram(test.Item1, test.Item2);
                Console.WriteLine($"Is anagram test: {test.Item1}, {test.Item2} Expected: {test.Item3} Got: {result}");
            }
        }
    }
}
