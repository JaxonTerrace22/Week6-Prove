using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace prove_06
{
    public static class MapsTester
    {
        // Entry method to be called in Program.cs
        public static void Run()
        {
            Console.WriteLine("Running MapsTester...\n");

            // Example file path for testing (update this with a valid file path)
            string filename = "degrees.csv";

            // Test Problem 2: SummarizeDegrees
            Console.WriteLine("Testing SummarizeDegrees:");
            var degreeSummary = SummarizeDegrees(filename);
            foreach (var entry in degreeSummary)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }

            Console.WriteLine("\nTesting IsAnagram:");
            Console.WriteLine($"listen vs silent: {IsAnagram("listen", "silent")}");
            Console.WriteLine($"hello vs world: {IsAnagram("hello", "world")}");
        }

        // Problem 2: SummarizeDegrees
        private static Dictionary<string, int> SummarizeDegrees(string filename)
        {
            var degrees = new Dictionary<string, int>();
            foreach (var line in File.ReadLines(filename))
            {
                var fields = line.Split(",");
                if (fields.Length >= 4)
                {
                    string degree = fields[3].Trim();
                    if (degrees.ContainsKey(degree))
                        degrees[degree]++;
                    else
                        degrees[degree] = 1;
                }
            }
            return degrees;
        }

        // Problem 3: IsAnagram
        private static bool IsAnagram(string word1, string word2)
        {
            string normalized1 = new string(word1.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();
            string normalized2 = new string(word2.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();

            if (normalized1.Length != normalized2.Length)
                return false;

            Dictionary<char, int> letterCounts = new Dictionary<char, int>();
            foreach (char c in normalized1)
            {
                if (letterCounts.ContainsKey(c))
                    letterCounts[c]++;
                else
                    letterCounts[c] = 1;
            }

            foreach (char c in normalized2)
            {
                if (!letterCounts.ContainsKey(c))
                    return false;
                letterCounts[c]--;
                if (letterCounts[c] < 0)
                    return false;
            }

            return true;
        }
    }
}
