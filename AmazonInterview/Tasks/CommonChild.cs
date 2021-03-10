using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonInterview.Tasks {
    public class CommonChild {
        public static int commonChild(string s1, string s2) {
            if (s1 == s2)
                return s1.Length;

            var tuples = BuildLetterMaps(s1, s2);
            var expanded1 = tuples.Item1;
            var s2map = tuples.Item2;
            var maxString = FindMax(expanded1, s2map);

            return maxString.Length;
        }

        private static string FindMax(char[] input, Dictionary<char, List<int>> map, int lowerLimit = 0, int mapLimit = -1) {
            var max = "";

            for (var i = lowerLimit; i < input.Length; i++) {
                var letter = input[i];
                var index = map[letter].FindIndex(p => p > mapLimit);

                if (index == -1)
                    continue;

                var characters = input[i] + FindMax(input, map, i + 1, map[letter][index]);

                if (characters.Length > max.Length)
                    max = characters;
            }

            return max;
        }

        private static Tuple<char[], Dictionary<char, List<int>>> BuildLetterMaps(string s1, string s2) {
            var h1 = new HashSet<char>(s1);
            var h2 = new HashSet<char>(s2);
            var expanded1 = new char[s1.Length];
            var dict2 = new Dictionary<char, List<int>>();
            var expanded2 = new char[s1.Length];

            for (var i = 0; i < s1.Length; i++) {
                if (h2.Contains(s1[i]))
                    expanded1[i] = s1[i];

                if (h1.Contains(s2[i])) {
                    if (!dict2.ContainsKey(s2[i]))
                        dict2[s2[i]] = new List<int> { i };
                    else
                        dict2[s2[i]].Add(i);
                }
            }

            return Tuple.Create(
                expanded1.Where(x => x != default(char)).ToArray(),
                dict2);
        }
    }
}
