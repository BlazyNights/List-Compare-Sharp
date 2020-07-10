using System;

namespace ListCompareSharp
{
    public static class Helper
    {
        public static string[] SplitLines(this string str) => str.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
    }
}
