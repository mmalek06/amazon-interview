using AmazonInterview.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonInterview.MIT {
    public static class NaiiveDocumentDistance {
        public static (double, string) Go(string query, IReadOnlyList<string> docs) {
            var cleanedQuery = GetOccurrences(GetWords(query));
            var cleanedDocs = docs.Select(x => GetOccurrences(GetWords(x)));
            var distances = cleanedDocs.Select(d => cleanedQuery.Dot(d)).ToList();
            var minDist = double.MaxValue;
            var whichDoc = string.Empty;

            for (var i = 0; i < docs.Count; i++) {
                if (distances[i] < minDist) {
                    minDist = distances[i];
                    whichDoc = docs[i].Ellipsize(32);
                }
            }

            return (minDist, whichDoc);
        }

        private static List<string> GetWords(string input) {
            // c# string can be at most 2,147,483,647 characters long 
            // which is equal to int.Max, hence implicit loop counter type
            var words = new List<string>();
            var currentWord = new StringBuilder();

            for (var i = 0; i < input.Length; i++) {
                if (!char.IsLetterOrDigit(input[i]) && currentWord.Length > 0) {
                    words.Add(currentWord.ToString());
                    currentWord.Clear();

                    continue;
                }
                if (char.IsLetterOrDigit(input[i]))
                    currentWord.Append(input[i]);
            }

            if (currentWord.Length > 0)
                words.Add(currentWord.ToString());

            return words;
        }

        private static Dictionary<string, int> GetOccurrences(IEnumerable<string> words) {
            var occurrences = new Dictionary<string, int>();

            foreach (var word in words) {
                if (occurrences.ContainsKey(word))
                    occurrences[word]++;
                else
                    occurrences[word] = 1;
            }

            return occurrences;
        }
    }
}
