namespace AmazonInterview.CombinatorialAlgorithms {
    public static class Functions {
        public static int NChooseK(int n, int k) {
            var result = 1;
            
            for (var i = 1; i <= k; i++) {
                result *= n - (k - i);
                result /= i;
            }

            return result;
        }
    }
}
