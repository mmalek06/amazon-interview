using System.Collections.Generic;

namespace AmazonInterview.Utils {
    public static class Lists {
        public static int FindFirstHigherValueIndex(this List<int> list, int target, int startingFrom = 0) {
            if (list == null || list.Count == 0)
                return -1;

            var low = startingFrom;
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
