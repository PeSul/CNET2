using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    internal class TextTools
    {
        public static Dictionary<string, int> FreqAnalysis(string file)
        {
            var content = File.ReadAllText(file);
            var words = content.Split(' ');

            Dictionary<string, int> dict = new();

            foreach (var word in words)
            {
                if (string.IsNullOrWhiteSpace(word))
                    continue;
                if (dict.ContainsKey(word))
                {
                    dict[word] = dict[word] + 1;
                }
                else
                {
                    dict.Add(word, 1);
                }
            }

            return dict;

        }
        public static Dictionary<string, int> GetTopWords(int takeTop, Dictionary<string, int> dict = new())
        {
            return dict;
        }
    

        public static IEnumerable<string> GetFilesFromDir(string dir)
        {
            return Directory.GetFiles(bookdir);
        }
    }
}
