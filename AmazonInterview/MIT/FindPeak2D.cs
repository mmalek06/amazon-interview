namespace AmazonInterview.MIT {
    public static class FindPeak2D {
        /// <summary>
        /// When a column max is found, it means the value is the biggest one in that column.
        /// Then if for example a value right to it is bigger, it means, it's bigger than all the values in the preceeding column.
        /// Then if a col max for the new column is found, it's guaranteed, it's bigger than all the values in the preceeding column as well.
        /// That way, gradually algo will find the answer.
        /// 
        /// Example call:
        /// 
        /// var m = new int[][] {
        ///     new int[] { 10, 8, 10, 10 },
        ///     new int[] { 14, 13, 12, 11},
        ///     new int[] { 15, 9, 11, 21 },
        ///     new int[] { 16, 17, 19, 20 }
        /// };
        /// var peek = FindPeak2D.Go(m);
        /// </summary>
        public static (int, int) Go(int[][] matrix) {
            (int, int)? peak = null;
            var cols = matrix[0].Length;
            var currentCol = cols / 2;

            while (peak is null) {
                var colMax = -1;
                var rowIdx = -1;

                for (var row = 0; row < matrix.Length; row++) {
                    if (matrix[row][currentCol] > colMax) {
                        colMax = matrix[row][currentCol];
                        rowIdx = row;
                    }
                }

                var left = currentCol > 0 ? matrix[rowIdx][currentCol - 1] : int.MinValue;
                var right = currentCol < cols - 1 ? matrix[rowIdx][currentCol + 1] : int.MinValue;
                var middle = matrix[rowIdx][currentCol];

                if (middle > left && middle > right)
                    peak = (rowIdx, currentCol);
                else if (middle < left)
                    currentCol = currentCol - 1;
                else if (middle < right)
                    currentCol = currentCol + 1;
            }

            return peak.Value;
        }
    }
}
