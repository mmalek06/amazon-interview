using System.Collections.Generic;
using System.Linq;

namespace AmazonInterview.Utils {
    public static class Permutations {
        public static void HeapPermutations<T>(this T[] a, int n, ICollection<IEnumerable<T>> result) {
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
