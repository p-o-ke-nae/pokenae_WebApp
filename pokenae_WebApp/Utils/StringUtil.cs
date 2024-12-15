namespace pokenae_WebApp.Utils
{
    public class StringUtil
    {
        public static string GetLastPart(string input, char splitter)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty", nameof(input));
            }

            var parts = input.Split(splitter);
            return parts[^1]; // C# 8.0以降のインデックス構文を使用
        }
    }
}
