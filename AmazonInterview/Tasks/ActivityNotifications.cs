using AmazonInterview.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonInterview.Tasks {
    //https://www.hackerrank.com/challenges/fraudulent-activity-notifications/problem
    //ActivityNotifications.Execute2(new[] { 2, 3, 4, 2, 3, 6, 8, 4, 5 }, 5); // 2 
    //ActivityNotifications.Execute2(new[] { 1, 2, 3, 4, 4 }, 4); // 0
    //ActivityNotifications.Execute2(new[] { 10, 20, 30, 40, 50 }, 3); // 1
    //ActivityNotifications.Execute2(Resource.expenditures.Split(' ').Select(v => Convert.ToInt32(v.Trim())).ToArray(), 10000); // 633
    //ActivityNotifications.Execute2(Resource.expenditures2.Split(' ').Select(v => Convert.ToInt32(v.Trim())).ToArray(), 30000); // 492 <- 
    // <- for this one I'm getting wrong answer, but I'm pretty sure my algorithm is correct
    // besides there are some solutions graded 100% on HR that are not calculating correct answers...
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

            var low = 0;
            var high = list.Count;

            while (low != high) {
                var mid = (low + high) / 2;

                if (list[mid] <= target) {
                    low = mid + 1;
                } else {
                    high = mid;
                }
            }

            return low;
        }
    }
}
