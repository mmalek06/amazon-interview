namespace AmazonInterview.Utils {
    public static class Strings {
        public static string Ellipsize(this string value, int maxChars) =>
            value.Length <= maxChars ? value : value.Substring(0, maxChars) + "...";
    }
}
