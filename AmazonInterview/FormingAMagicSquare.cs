using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonInterview {
    // https://www.hackerrank.com/challenges/magic-square-forming/problem
    public class FormingAMagicSquare {
        private const int GoalSum = 15;
        private static readonly int[] Numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        public int FormingMagicSquare(int[][] s) {
            if (s.Length < 2)
                return 0;

            var flatInput = FlattenArray(s);
            var permutations = new List<IEnumerable<int>>();
            
            Permutations.HeapPermutations(Numbers, Numbers.Length, permutations);

            var validSquares = GetValidSquares(permutations);
            var minCost = MinimazeTransformationCost(flatInput, validSquares);

            return minCost;
        }

        private static int[] FlattenArray(int[][] s) {
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

        private static int[][] GetValidSquares(IEnumerable<IEnumerable<int>> permutations) {
            var result = new List<int[]>();

            foreach (var permutation in permutations) {
                var permutationArray = permutation.ToArray();
                var firstRowMagic = IsSeriesMagic(permutationArray, 0, 1);
                var diagonalMagic = IsSeriesMagic(permutationArray, 0, 3);
                var firstColumnMagic = IsSeriesMagic(permutationArray, 0, 4);
                var middleColumnMagic = IsSeriesMagic(permutationArray, 1, 3);
                var secondDiagonalMagic = IsSeriesMagic(permutationArray, 2, 2);
                var secondColumnMagic = IsSeriesMagic(permutationArray, 2, 3);
                var secondRowMagic = IsSeriesMagic(permutationArray, 3, 1);
                var thirdRowMagic = IsSeriesMagic(permutationArray, 6, 1);

                if (firstRowMagic && diagonalMagic && firstColumnMagic && middleColumnMagic && secondDiagonalMagic && 
                    secondColumnMagic && secondRowMagic && thirdRowMagic)
                    result.Add(permutation.ToArray());
            }

            return result.ToArray();
        }

        private static bool IsSeriesMagic(int[] flat, int start, int step) {
            var sum = 0;

            for (int i = start, counter = 0; i < flat.Length && counter < 3; i+= step, counter++)
                sum += i > flat.Length ? 0 : flat[i];

            return sum == GoalSum;
        }

        private static int MinimazeTransformationCost(int[] input, int[][] validSquares) {
            var minCost = int.MaxValue;

            foreach (var magicSquare in validSquares) {
                var currentCost = 0;

                for (var i = 0; i < magicSquare.Length; i++) {
                    currentCost += Math.Abs(input[i] - magicSquare[i]);

                    if (currentCost < minCost)
                        minCost = currentCost;
                }
            }

            return minCost;
        }
    }
}
