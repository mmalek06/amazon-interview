namespace AmazonInterview {
    class Program {
        static void Main(string[] args) {
            var alg = new FormingAMagicSquare();

            alg.FormingMagicSquare(new int[3][] {
                new int[]{ 5, 3, 4 },
                new int[]{ 1, 5, 8 },
                new int[]{ 6, 4, 2}
            });
        }
    }
}
