using System.Collections.Generic;

namespace AmazonInterview.Tasks {
    // https://www.hackerrank.com/challenges/richie-rich/problem
    public static class HighestValuePalindrome {
        public static string Execute(string s, int n, int changesAllowed) {
            var chars = s.ToCharArray();
            var halfLen = s.Length / 2;
            var changedIndexes = new HashSet<int>(changesAllowed);

            InitializePalindrome(chars, halfLen, changedIndexes, ref changesAllowed);

            if (changesAllowed <= 0)
                return IsPalindrome(chars) ? new string(chars) : "-1";

            if (changesAllowed > 0)
                ImprovePalindrome(chars, changedIndexes, changesAllowed);

            return IsPalindrome(chars) ? new string(chars) : "-1";
        }

        private static void InitializePalindrome(char[] chars, int halfLen, HashSet<int> changedIndexes, ref int changesAllowed) {
            for (var i = 0; i < halfLen && changesAllowed > 0; i++) {
                if (chars[i] != chars[chars.Length - 1 - i]) {
                    var left = (int)char.GetNumericValue(chars[i]);
                    var right = (int)char.GetNumericValue(chars[chars.Length - 1 - i]);

                    if (left > right) {
                        chars[chars.Length - 1 - i] = char.Parse(left.ToString());
                        changesAllowed--;

                        changedIndexes.Add(chars.Length - 1 - i);
                    }
                    if (left < right) {
                        chars[i] = char.Parse(right.ToString());
                        changesAllowed--;

                        changedIndexes.Add(i);
                    }
                }
            }
        }

        private static bool IsPalindrome(char[] chars) {
            for (var i = 0; i < chars.Length / 2; i++) {
                if (chars[i] != chars[chars.Length - 1 - i])
                    return false;
            }

            return true;
        }

        private static void ImprovePalindrome(char[] chars, HashSet<int> changedIndexes, int changesAllowed) {
            for (var i = 0; i < chars.Length / 2 && changesAllowed > 0; i++) {
                if (chars[i] != '9') {
                    if (changedIndexes.Contains(i) || changedIndexes.Contains(chars.Length - 1 - i)) {
                        chars[i] = '9';
                        chars[chars.Length - 1 - i] = '9';
                        changesAllowed--;
                    } else if (changesAllowed >= 2) {
                        chars[i] = '9';
                        chars[chars.Length - 1 - i] = '9';
                        changesAllowed -= 2;
                    }
                }
            }

            if (changesAllowed > 0 && chars.Length % 2 == 1) {
                var mid = chars.Length / 2;

                chars[mid] = '9';
            }
        }
    }
}