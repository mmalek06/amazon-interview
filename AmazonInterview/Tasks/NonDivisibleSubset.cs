using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonInterview.Tasks {
    public static class NonDivisibleSubset {
        // similar in spirit to: https://cs.stackexchange.com/a/57876
        // NonDivisibleSubset.ExecuteFast(3, new List<int> { 1, 7, 2, 4 });
        // NonDivisibleSubset.ExecuteFast(7, new List<int> { 278, 576, 496, 727, 410, 124, 338, 149, 209, 702, 282, 718, 771, 575, 436 });
        public static int ExecuteFast(int k, List<int> a) {
            var mk = new int[k];
            
            for (int i = 0; i < a.Count; i++) 
                mk[a[i] % k]++;
            
            var x = 0;

            if (mk[0] > 0) 
                x++;
            
            for (int i = 1; i < (k + 1) / 2; i++)
                x += Math.Max(mk[i], mk[k - i]);

            if (k % 2 == 0 && mk[k / 2] > 0) 
                x++;

            return x;
        }

        public static int ExecuteSlow(int k, List<int> s) {
            var max = 0;
            var currentList = new List<int>();

            for (var i = 0; i < s.Count; i++) {
                currentList.Add(s[i]);

                for (var j = 0; j < s.Count; j++) {
                    if (i == j)
                        continue;

                    if (!currentList.Any(x => SumDivisible(x, s[j], k)))
                        currentList.Add(s[j]);
                }

                if (currentList.Count > max)
                    max = currentList.Count;

                currentList.Clear();
            }

            return max;
        }

        private static bool SumDivisible(int a, int b, int k) =>
            (a + b) % k == 0;
    }
}
