using System;
using System.Collections.Generic;

namespace Week6_Prove
{
    public class Translator
    {
        private readonly Dictionary<string, string> _words = new();

        public void AddWord(string fromWord, string toWord)
        {
            _words[fromWord] = toWord;
        }

        public string Translate(string fromWord)
        {
            return _words.ContainsKey(fromWord) ? _words[fromWord] : "???";
        }
    }
}