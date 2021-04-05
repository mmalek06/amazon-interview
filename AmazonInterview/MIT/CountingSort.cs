using System.Collections.Generic;

namespace AmazonInterview.MIT {
    public static class CountingSort {
        public static int[] Go(int[] arr) {
            var k = -1;

            for (var i = 0; i < arr.Length; i++) {
                if (arr[i] > k)
                    k = arr[i];
            }

            var counts = new List<int>[k + 1];

            for (var i = 0; i < arr.Length; i++) {
                if (counts[arr[i]] is null)
                    counts[arr[i]] = new List<int>(k);

                counts[arr[i]].Add(arr[i]);
            }

            var result = new int[arr.Length];
            var resultIndex = 0;

            foreach (var row in counts) {
                if (row is null)
                    continue;

                for (var i = 0; i < row.Count; i++) {
                    result[resultIndex] = row[i];
                    resultIndex++;
                }
            }

            return result;
        }
    }
}
