namespace AmazonInterview.Utils {
    public class MatrixTranspose {
        public int[][] T(int [][] s) {
            var sT = new int[s.Length][];

            for (var i = 0; i < s.Length; i++) {
                for (var j = 0; j < s[i].Length; j++) {
                    if (sT[j] == null)
                        sT[j] = new int[s[i].Length];

                    sT[j][i] = s[i][j];
                }
            }

            return sT;
        }
    }
}
