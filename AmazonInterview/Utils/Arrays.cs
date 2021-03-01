namespace AmazonInterview.Utils {
    public static class Arrays {
        public static int[] FlattenArray(this int[][] s) {
            var flat = new int[s.Length * s[0].Length];
            var idx = 0;

            for (var i = 0; i < s.Length; i++) {
                for (var j = 0; j < s[i].Length; j++) {
                    flat[idx] = s[i][j];
                    idx++;
                }
            }

            return flat;
        }
    }
}
