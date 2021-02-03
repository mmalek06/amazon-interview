using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonInterview {
    // https://www.hackerrank.com/challenges/magic-square-forming/problem
    public class FormingAMagicSquare {
        private const int GoalSum = 15;
        private static readonly int[] Numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        // 5 3 4
        // 1 5 8
        // 6 4 2
        // 5 3 4 1 5 8 6 4 2
        // 5     1     6
        // 5       5       2

        // 8 3 4
        // 1 5 9
        // 6 7 2
        // 8 3 4 1 5 9 6 7 2
        public int FormingMagicSquare(int[][] s) {
            if (s.Length < 2)
                return 0;

            var flat = FlattenArray(s);
            var permutations = Permutations();

            return 0;
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

        private static int[][] Permutations() {


            // 1 _ _ _ _ _ _ _ _
            // 2
            // 3
            // 4
            // 5
            // 6
            // 7
            // 8
            // 9

            return null;
        }

        public static int GetNumber(int[] excluded) =>
                Numbers.FirstOrDefault(n => !excluded.Contains(n));

        public static int GetNumber(int excluded) =>
            Numbers.FirstOrDefault(n => n != excluded);

        private static bool IsSeriesMagic(int[] flat, int step) {
            var sum = 0;
            var isMagic = false;
            int i;

            for (i = 0; i < flat.Length; i += step)
                sum += i > flat.Length ? 0 : flat[i];

            if (i <= flat.Length && sum == GoalSum)
                isMagic = true;

            return isMagic;
        }
    }
}
