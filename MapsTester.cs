using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using Week6_Prove;

namespace prove_06
{
    public static class MapsTester
    {
        public static void Run()
        {
            Console.WriteLine("\n=========== problem 1 tests ===========");
            var englishToGerman = new Translator();
            englishToGerman.AddWord("House", "Haus");
            englishToGerman.AddWord("Car", "Auto");
            englishToGerman.AddWord("Plane", "Flugzeug");
            Console.WriteLine(englishToGerman.Translate("Car"));
            Console.WriteLine(englishToGerman.Translate("Plane"));
            Console.WriteLine(englishToGerman.Translate("Train"));

            Console.WriteLine("\n=========== problem 2 tests ===========");
            try
            {
                Console.WriteLine(SummarizeDegrees("census.txt").AsString());
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Warning: the census.txt could not be found. Skipping over problem 2");
            }

            Console.WriteLine("\n=========== problem 3 tests ===========");
            Console.WriteLine(IsAnagram("CAT", "ACT"));
            Console.WriteLine(IsAnagram("DOG", "GOOD"));
            Console.WriteLine(IsAnagram("AABBCCDD", "ABCD"));
            Console.WriteLine(IsAnagram("ABCCD", "ABBCD"));
            Console.WriteLine(IsAnagram("BC", "AD"));
            Console.WriteLine(IsAnagram("Ab", "Ba"));
            Console.WriteLine(IsAnagram("A Decimal Point", "Im a Dot in Place"));
            Console.WriteLine(IsAnagram("tom marvolo riddle", "i am lord voldemort"));
            Console.WriteLine(IsAnagram("Eleven plus Two", "Twelve Plus One"));
            Console.WriteLine(IsAnagram("Eleven plus One", "Twelve Plus One"));

            Console.WriteLine("\n=========== problem 4 tests ===========");
            Dictionary<(int, int), bool[]> map = SetupMazeMap();
            var maze = new Maze(map);

            maze.ShowStatus();
            maze.MoveUp();
            maze.MoveLeft();
            maze.MoveRight();
            maze.MoveRight();
            maze.MoveDown();
            maze.MoveDown();
            maze.MoveDown();
            maze.MoveRight();
            maze.MoveRight();
            maze.MoveUp();
            maze.MoveRight();
            maze.MoveDown();
            maze.MoveLeft();
            maze.MoveDown();
            maze.MoveRight();
            maze.MoveDown();
            maze.MoveDown();
            maze.MoveRight();
            maze.ShowStatus();

            Console.WriteLine("\n=========== problem 5 tests ===========");
            EarthquakeDailySummary();
        }

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

        private static bool IsAnagram(string word1, string word2)
        {
            string normalized1 = new string(word1.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();
            string normalized2 = new string(word2.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();
            if (normalized1.Length != normalized2.Length)
                return false;
            
            Dictionary<char, int> letterCounts = new();
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

        private static Dictionary<(int, int), bool[]> SetupMazeMap()
        {
            return new Dictionary<(int, int), bool[]>
            {
                { (1, 1), new[] { false, true, false, true } },
                { (1, 2), new[] { false, true, true, false } },
                { (1, 3), new[] { false, false, false, false } },
                { (1, 4), new[] { false, true, false, true } },
                { (1, 5), new[] { false, false, true, true } },
                { (1, 6), new[] { false, false, true, false } },
                { (2, 1), new[] { true, false, false, true } },
                { (2, 2), new[] { true, false, true, true } },
                { (2, 3), new[] { false, false, true, true } },
                { (2, 4), new[] { true, true, true, false } },
                { (2, 5), new[] { false, false, false, false } },
                { (2, 6), new[] { false, false, false, false } },
                { (3, 1), new[] { false, false, false, false } },
                { (3, 2), new[] { false, false, false, false } },
                { (3, 3), new[] { false, false, false, false } },
                { (3, 4), new[] { true, true, false, true } },
                { (3, 5), new[] { false, false, true, true } },
                { (3, 6), new[] { false, false, true, false } },
                { (4, 1), new[] { false, true, false, false } },
                { (4, 2), new[] { false, false, false, false } },
                { (4, 3), new[] { false, true, false, true } },
                { (4, 4), new[] { true, true, true, false } },
                { (4, 5), new[] { false, false, false, false } },
                { (4, 6), new[] { false, false, false, false } },
                { (5, 1), new[] { true, true, false, true } },
                { (5, 2), new[] { false, false, true, true } },
                { (5, 3), new[] { true, true, true, true } },
                { (5, 4), new[] { true, false, true, true } },
                { (5, 5), new[] { false, false, true, true } },
                { (5, 6), new[] { false, true, true, false } },
                { (6, 1), new[] { true, false, false, false } },
                { (6, 2), new[] { false, false, false, false } },
                { (6, 3), new[] { true, false, false, false } },
                { (6, 4), new[] { false, false, false, false } },
                { (6, 5), new[] { false, false, false, false } },
                { (6, 6), new[] { true, false, false, false } }
            };
        }

        private static void EarthquakeDailySummary()
        {
            const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
            using var client = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Get, uri);
            using var response = client.SendAsync(request).Result;
            using var jsonStream = response.Content.ReadAsStream();
            using var reader = new StreamReader(jsonStream);
            var json = reader.ReadToEnd();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
            if (featureCollection == null)
                return;
            foreach (var feature in featureCollection.Features)
            {
                Console.WriteLine($"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
            }
        }
    }

    public static class Extensions
    {
        public static string AsString<TKey, TValue>(this Dictionary<TKey, TValue> dict) where TKey : notnull
        {
            return "<dictionary>{" + string.Join(", ", dict.Select(kvp => $"[{kvp.Key}, {kvp.Value}]")) + "}";
        }
    }
}
