using System;

namespace AdbUtils
{
    public static class ExtensionMethodsString
    {
        public static string EncodeUrl(this string str) => Uri.EscapeUriString(str);
        
    }
}
