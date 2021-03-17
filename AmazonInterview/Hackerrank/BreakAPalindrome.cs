namespace AmazonInterview.Hackerrank {
    public class BreakAPalindrome {
        public string Execute(string palindrome) {
            if (string.IsNullOrEmpty(palindrome) || palindrome.Length == 1)
                return string.Empty;

            char? character = null;
            var idx = -1;

            for (var i = 0; i < palindrome.Length; i++) {
                if (palindrome.Length % 2 == 1 && i == palindrome.Length / 2)
                    continue;
                if (palindrome[i] != 'a') {
                    character = 'a';
                    idx = i;

                    break;
                }
                if (palindrome[i] == 'a' && i == palindrome.Length - 1) {
                    character = 'b';
                    idx = i;
                }
            }

            if (character is null)
                return string.Empty;

            return palindrome.Substring(0, idx) + character + palindrome.Substring(idx + 1);
        }
    }
}
