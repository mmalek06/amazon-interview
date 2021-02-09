using System;
using System.Linq;

namespace AmazonInterview.Tasks {
    public static class ActivityNotifications {
        public static int Execute2(int[] expenditures, int d) {
            var notificationsCount = 0;
            var slice = new int[d];
            
            for (var i = d; i < expenditures.Length; i++) {
                int sliceIndexToRemove;
                
                if (i == d) {
                    var indexes = Enumerable.Range(0, d).ToArray();

                    Array.Copy(expenditures, i - d, slice, 0, d);
                    Array.Sort(slice, indexes);

                    sliceIndexToRemove = indexes[0];
                } else {
                    var pair = BalanceSlice(slice, expenditures[i - 1], expenditures[i - d]);

                    slice = pair.Item1;
                    sliceIndexToRemove = pair.Item2;
                }

                var value = expenditures[i];
                var median = CalculateMedian(slice);

                if (value >= 2 * median)
                    notificationsCount++;

                slice[sliceIndexToRemove] = int.MinValue;
            }

            return notificationsCount;
        }

        private static Tuple<int[], int> BalanceSlice(int[] slice, int first, int valueToRemove) {
            var result = new int[slice.Length];
            var indexToRemove = -1;
            int resultIndex, sliceIndex;

            for (resultIndex = 0, sliceIndex = 0; resultIndex < result.Length; resultIndex++, sliceIndex++) {
                if (sliceIndex < slice.Length && slice[sliceIndex] == int.MinValue)
                    sliceIndex++;
                if (sliceIndex >= slice.Length) {
                    if (first != int.MinValue)
                        result[resultIndex] = first;
                } else {
                    if (first != int.MinValue && slice[sliceIndex] >= first) {
                        result[resultIndex] = first;
                        first = int.MinValue;
                        sliceIndex--;
                    } else
                        result[resultIndex] = slice[sliceIndex];
                }

                if (indexToRemove == -1 && result[resultIndex] == valueToRemove)
                    indexToRemove = resultIndex;
            }

            return Tuple.Create(result, indexToRemove);
        }

        private static double CalculateMedian(int[] values) {
            if (values.Length % 2 == 0) {
                var middleLeft = values[(int)Math.Floor((values.Length - 1) / 2f)];
                var middleRight = values[values.Length / 2];

                return (middleLeft + middleRight) / 2f;
            }

            return values[values.Length / 2];
        }
    }
}
