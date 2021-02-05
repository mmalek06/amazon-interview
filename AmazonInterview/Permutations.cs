using System.Collections.Generic;
using System.Linq;

namespace AmazonInterview {
    public static class Permutations {
        public static IReadOnlyList<IReadOnlyList<int>> SlowPermutations(int[] numbers) {
            var roots = new List<NaryNode<int>>();

            for (var startNumber = 1; startNumber < 10; startNumber++) {
                var root = new NaryNode<int>(startNumber);

                for (var index = 1; index < 9; index++) {
                    var permutationsSoFar = root.InOrder();

                    for (var i = 0; i < permutationsSoFar.Count; i++) {
                        var forbiddenNumbers = permutationsSoFar[i][permutationsSoFar[i].Count - 1].ToRootValuesOnly();

                        for (var @try = 0; @try < 9 - index; @try++) {
                            var number = GetNumber(forbiddenNumbers);

                            permutationsSoFar[i].Last().Add(number);
                            forbiddenNumbers.Add(number);
                        }
                    }
                }

                roots.Add(root);
            }

            var result = roots.SelectMany(r => r.InOrderValuesOnly()).ToList();

            return result;

            int GetNumber(IEnumerable<int> excluded) =>
                numbers.FirstOrDefault(n => !excluded.Contains(n));
        }

        public static void HeapPermutations(int[] a, int size, int n, List<IEnumerable<int>> result) {
            if (size == 1)
                result.Add(a.ToList());

            for (var i = 0; i < size; i++) {
                HeapPermutations(a, size - 1, n, result);

                if (size % 2 == 1) {
                    var temp = a[0];

                    a[0] = a[size - 1];
                    a[size - 1] = temp;
                } else {
                    var temp = a[i];

                    a[i] = a[size - 1];
                    a[size - 1] = temp;
                }
            }
        }
    }
}
