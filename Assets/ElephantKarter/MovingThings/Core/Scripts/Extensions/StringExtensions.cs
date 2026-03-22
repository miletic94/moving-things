public static class StringExtensions
{
    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }
    public static string Format(this string formatString, params object[] args)
    {
        return string.Format(formatString, args);
    }
}