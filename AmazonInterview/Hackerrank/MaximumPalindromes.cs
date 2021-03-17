using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonInterview.Hackerrank {
    //there are some edge cases where it doesn't work. will get back to it when I have more time.
    //var a = Resource.maximumpalindromes_test3.Split(Environment.NewLine).Select(x => x.Split(" ").Select(int.Parse).ToArray()).ToArray();
    //var b = Resource.maximumpalindromes_ans3.Split(Environment.NewLine).Select(int.Parse).ToArray();

    //for (var i = 0; i<a.Length; i++) {
    //    var ans = MaximumPalindromes.answerQuery(a[i][0], a[i][1]);
    //    var actualAns = b[i];
    //}
    public class MaximumPalindromes {
        private static string _s;

        public static void initialize(string s) {
            _s = s;
        }

        public static int answerQuery(int l, int r) {
            var slice = _s.Skip(l - 1).Take(r - l + 1).ToArray();
            var repetitions = BuildRepetitionsDict(slice);

            if (repetitions.Count == 1)
                return 1;

            var combinations = GetPalindromicCombinations(repetitions);
            var repeatingFactorials = new List<int>();
            var max = 0L;

            foreach (var combination in combinations) {
                var lengthFactorial = Factorial(combination.Sum(kvp => kvp.Value) / 2);

                repeatingFactorials.Clear();

                foreach (var kvp in combination) {
                    if (kvp.Value / 2 > 0)
                        repeatingFactorials.Add(kvp.Value / 2);
                }

                var currentCount = lengthFactorial / repeatingFactorials.Select(Factorial).Aggregate(1, (a, b) => a * b);

                max += currentCount;
            }

            return (int)(max % (Math.Pow(10, 9) + 7));
        }

        private static Dictionary<char, int> BuildRepetitionsDict(IEnumerable<char> letters) {
            var repetitions = new Dictionary<char, int>();

            foreach (var letter in letters) {
                if (!repetitions.ContainsKey(letter))
                    repetitions.Add(letter, 0);

                repetitions[letter]++;
            }

            return repetitions;
        }

        private static IEnumerable<Dictionary<char, int>> GetPalindromicCombinations(Dictionary<char, int> repetitions) {
            var evenRepetitions = new Dictionary<char, int>();
            var unevenRepetitions = new Dictionary<char, int>();
            var result = new List<Dictionary<char, int>>();

            foreach (var kvp in repetitions) {
                if (repetitions[kvp.Key] % 2 == 0)
                    evenRepetitions[kvp.Key] = kvp.Value;
                else
                    unevenRepetitions[kvp.Key] = kvp.Value;
            }

            if (unevenRepetitions.Any()) {
                foreach (var kvp in unevenRepetitions) {
                    var dict = evenRepetitions.ToDictionary(x => x.Key, x => x.Value);

                    foreach (var kvp2 in unevenRepetitions) {
                        if (kvp2.Key == kvp.Key)
                            dict[kvp2.Key] = kvp2.Value;
                        else {
                            var val = kvp2.Value - 1;

                            if (val > 0)
                                dict[kvp2.Key] = val;
                        }
                    }

                    result.Add(dict);
                }
            } else
                result.Add(evenRepetitions);

            return result;
        }

        private static int Factorial(int n) {
            var result = 1;

            for (var i = 1; i <= n; i++)
                result *= i;

            return result;
        }
    }
}
