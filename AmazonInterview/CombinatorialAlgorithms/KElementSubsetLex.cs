using System;
using static AmazonInterview.CombinatorialAlgorithms.Functions;

namespace AmazonInterview.CombinatorialAlgorithms {
    public static class KElementSubsetLex {
        public static int[] Successor(int[] T, int k, int n) {
            var U = new int[T.Length];
            var i = k - 1;

            Array.Copy(T, U, T.Length);

            // decrease i until a number lower than calculated max is encountered
            // if every number is its positions max, then i will be equal to 0 and
            // no successor could be found
            while (i >= 1 && T[i] == (n - k + i + 1)) 
                i--;

            if (i == 0)
                return null;

            // adjust: numbers to small will be increased, numbers to big will be decreased
            for (var j = i; j < k; j++)
                U[j] = T[i] + 1 + j - i;

            return U;
        }

        public static int Rank(int[] T, int k, int n) {
            var r = 0;
            var TV = new int[T.Length];

            Array.Copy(T, TV, T.Length);

            TV[0] = 0;

            for (var i = 1; i < k; i++) {
                if (TV[i - 1] + 1 <= TV[i] - 1) {
                    for (var j = TV[i - 1] + 1; j < TV[i] - 1; j++)
                        r += NChooseK(n - j, k - i);
                }
            }

            return r;
        }
    }
}
