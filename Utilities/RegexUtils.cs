using System.Text.RegularExpressions;

namespace TradeSoftTask.Utilities;

static class RegexUtils
{
    public static String NormalizeString(String data)
    {
        return Regex.Replace(data, @"[^\w\d]", String.Empty).ToLower();
    }

    public static Boolean IsStringEmpty(String targetStr, params String[] strings)
    {
        foreach (String str in strings)
        {
            targetStr = targetStr.Replace(NormalizeString(str), String.Empty);
        }

        return targetStr.Length == 0;
    }
}