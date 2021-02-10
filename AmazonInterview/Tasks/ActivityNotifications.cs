using AmazonInterview.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonInterview.Tasks {
    public static class ActivityNotifications {
        public static int Execute2(int[] expenditures, int d) {
            var notificationsCount = 0;
            var slice = new List<int>(d);
            
            for (var i = d; i < expenditures.Length; i++) {
                int sliceIndexToRemove;

                if (i == d) {
                    var indexes = Enumerable.Range(0, d).ToArray();
                    var tmpSlice = new int[d];

                    Array.Copy(expenditures, i - d, tmpSlice, 0, d);
                    Array.Sort(tmpSlice, indexes);
                    slice.AddRange(tmpSlice);

                    sliceIndexToRemove = indexes[0];
                } else {
                    var insertionIndex = FindFirstHigherValue(slice, expenditures[i - 1]);

                    if (insertionIndex < 0)
                        slice.Add(expenditures[i - 1]);
                    else
                        slice.Insert(insertionIndex, expenditures[i - 1]);
                    
                    sliceIndexToRemove = slice.BinarySearch(expenditures[i - d]);
                }

                var value = expenditures[i];
                var median = CalculateMedian(slice);

                if (value >= 2 * median)
                    notificationsCount++;

                slice.RemoveAt(sliceIndexToRemove);
            }

            return notificationsCount;
        }

        private static double CalculateMedian(List<int> values) {
            if (values.Count % 2 == 0) {
                var middleLeft = values[(int)Math.Floor((values.Count - 1) / 2f)];
                var middleRight = values[values.Count / 2];

                return (middleLeft + middleRight) / 2f;
            }

            return values[values.Count / 2];
        }

        private static int FindFirstHigherValue(List<int> list, int target) {
            if (list == null || list.Count == 0)
                return -1;

            var left = 0;
            var right = list.Count - 1;

            while (left <= right) {
                var middle = left + (right - left) / 2;

                if (list[middle] > target)
                    right = middle - 1;
                else if (list[middle] < target)
                    left = middle + 1;
                else
                    return middle;
            }

            return -1;
        }
    }
}
