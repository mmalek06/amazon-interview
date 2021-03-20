namespace AmazonInterview.MIT {
    public static class MergeSort {
        public static int[] Go(int[] x) =>
            Sort(x, 0, x.Length - 1);

        private static int[] Sort(int[] x, int start, int end) {
            if (start >= end)
                return new[] { x[start] };

            var midPoint = (start + (end - 1)) / 2;
            var left = Sort(x, start, midPoint);
            var right = Sort(x, midPoint + 1, end);
            
            return Merge(left, right);
        }

        private static int[] Merge(int[] left, int[] right) {
            var result = new int[left.Length + right.Length];
            var leftCursor = 0;
            var rightCursor = 0;

            for (var i = 0; i < result.Length; i++) {
                if (leftCursor >= left.Length) {
                    result[i] = right[rightCursor];
                    rightCursor++;
                } else if (rightCursor >= right.Length) {
                    result[i] = left[leftCursor];
                    leftCursor++;
                } else if (left[leftCursor] > right[rightCursor]) {
                    result[i] = right[rightCursor];
                    rightCursor++;
                } else {
                    result[i] = left[leftCursor];
                    leftCursor++;
                }
            }

            return result;
        }
    }
}
