using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonInterview.Utils {
    public static class Vector {
        public static double Dot(this Dictionary<string, int> a, Dictionary<string, int> b) {
            var numerator = SummedProduct(a, b);
            var denominator = Math.Sqrt(SummedProduct(a, a) * SummedProduct(b, b));

            return Math.Acos(numerator / denominator);
        }

        public static double Dot(this IReadOnlyList<int> a, IReadOnlyList<int> b) {
            var (first, second) = a.Count <= b.Count ? (a, b) : (b, a);
            var numerator = SummedProduct(first, second);
            var denominator = Math.Sqrt(SummedProduct(first, first) * SummedProduct(second, second));

            return Math.Acos(numerator / denominator);
        }

        private static int SummedProduct(IReadOnlyList<int> first, IReadOnlyList<int> second) =>
            first.Select((x, i) => x * second[i]).Sum();

        private static int SummedProduct(Dictionary<string, int> first, Dictionary<string, int> second) {
            var sum = 0;

            foreach (var kvp in first) {
                if (second.ContainsKey(kvp.Key))
                    sum += kvp.Value * second[kvp.Key];
            }

            return sum;
        }
    }
}
