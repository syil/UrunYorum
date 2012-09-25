using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrunYorum.Base
{
    public static class ExtensionMethods
    {
        public static string FormatWith(this string formatStr, params object[] args)
        {
            return string.Format(formatStr, args);
        }
    }
}
