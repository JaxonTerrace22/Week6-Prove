namespace prove_06
{
    public static class MapsTester
    {
        // Problem 2: SummarizeDegrees
        private static Dictionary<string, int> SummarizeDegrees(string filename)
        {
            var degrees = new Dictionary<string, int>();
            foreach (var line in System.IO.File.ReadLines(filename))
            {
                var fields = line.Split(",");
                // Todo Problem 2 - ADD YOUR CODE HERE
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
            // normalize both words: remove spaces, convert to lowercase
            string normalized1 = new string(word1.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();
            string normalized2 = new string(word2.Where(c => !char.IsWhiteSpace(c)).ToArray()).ToLower();

            // normalized strings are different lengths, they can't be anagrams
            if (normalized1.Length != normalized2.Length)
                return false;

            //  dictionary to count frequency of each character in first word
            Dictionary<char, int> letterCounts = new Dictionary<char, int>();
            foreach (char c in normalized1)
            {
                if (letterCounts.ContainsKey(c))
                    letterCounts[c]++;
                else
                    letterCounts[c] = 1;
            }

            // for each character in second word, decrement count in dictionary
            foreach (char c in normalized2)
            {
                if (!letterCounts.ContainsKey(c))
                    return false;
                letterCounts[c]--;
                if (letterCounts[c] < 0)
                    return false;
            }

            // if all counts zero, words are anagrams
            return true;
        }
    }
}
