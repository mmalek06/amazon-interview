using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonInterview.Tasks {
    public class CommonChild {
        public static int commonChild(string s1, string s2) {
            if (s1 == s2)
                return s1.Length;

            var tuples = BuildLetterMaps(s1, s2);
            var s1map = tuples.Item1;
            var expanded1 = tuples.Item2;
            var s2map = tuples.Item3;
            var expanded2 = tuples.Item4;
            var max1 = FindMax(expanded1, s2map);
            var max2 = FindMax(expanded2, s1map);

            return Math.Max(max1, max2);
        }

        private static int FindMax(char[] input, Dictionary<char, List<int>> map) {
            var max = 0;

            for (var i = 0; i < input.Length; i++) {
                var prevLimit = -1;
                var currentMax = 0;

                for (var j = i; j < input.Length; j++) {
                    var letter = input[j];
                    var index = map[letter].FindIndex(p => p > prevLimit);

                    if (index == -1)
                        continue;

                    prevLimit = map[letter][index];
                    currentMax++;
                }

                if (currentMax > max)
                    max = currentMax;
            }

            return max;
        }

        private static Tuple<Dictionary<char, List<int>>, char[], Dictionary<char, List<int>>, char[]> BuildLetterMaps(string s1, string s2) {
            var h1 = new HashSet<char>(s1);
            var h2 = new HashSet<char>(s2);
            var dict1 = new Dictionary<char, List<int>>();
            var expanded1 = new char[s1.Length];
            var dict2 = new Dictionary<char, List<int>>();
            var expanded2 = new char[s1.Length];

            for (var i = 0; i < s1.Length; i++) {
                if (h2.Contains(s1[i])) {
                    if (!dict1.ContainsKey(s1[i]))
                        dict1[s1[i]] = new List<int> { i };
                    else
                        dict1[s1[i]].Add(i);

                    expanded1[i] = s1[i];
                }

                if (h1.Contains(s2[i])) {
                    if (!dict2.ContainsKey(s2[i]))
                        dict2[s2[i]] = new List<int> { i };
                    else
                        dict2[s2[i]].Add(i);

                    expanded2[i] = s2[i];
                }
            }

            return Tuple.Create(
                dict1, 
                expanded1.Where(x => x != default(char)).ToArray(),
                dict2, 
                expanded2.Where(x => x != default(char)).ToArray());
        }
    }
}
