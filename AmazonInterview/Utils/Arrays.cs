using System.Collections.Generic;
using System.Linq;

namespace AmazonInterview.Utils {
    public static class Arrays {
        public static int[] FlattenArray(this int[][] s) {
            var flat = new int[s.Length * s[0].Length];
            var idx = 0;

            for (var i = 0; i < s.Length; i++) {
                for (var j = 0; j < s[i].Length; j++) {
                    flat[idx] = s[i][j];
                    idx++;
                }
            }

            return flat;
        }

        public static void HeapPermutations<T>(this T[] a, int n, List<IEnumerable<T>> result) {
            if (n == 1)
                result.Add(a.ToList());

            for (var i = 0; i < n; i++) {
                HeapPermutations(a, n - 1, result);

                if (n % 2 == 1) {
                    var temp = a[0];

                    a[0] = a[n - 1];
                    a[n - 1] = temp;
                } else {
                    var temp = a[i];

                    a[i] = a[n - 1];
                    a[n - 1] = temp;
                }
            }
        }
    }
}
