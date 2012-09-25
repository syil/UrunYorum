using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrunYorum.Base.Utilities
{
    public static class StringOperations
    {
        private const string UnicodeCharacters        = "çğışöüÇĞİŞÖÜ";
        private const string ReplaceUnicodeCharacters = "cgisouCGISOU";

        public static string UrlFriendlyString(string str)
        {
            StringBuilder sb = new StringBuilder();
            char ch;

            for (int i = 0; i < str.Length; i++)
            {
                ch = str[i];

                if (char.IsLetterOrDigit(ch))
                {
                    if (IsUnicodeCharacter(ch))
                        sb.Append(ReplaceUnicodeCharacter(ch));
                    else
                        sb.Append(ch);
                }
                else if(char.IsWhiteSpace(ch))
                {
                    sb.Append("-");
                }
            }

            return sb.ToString().ToLower();
        }

        public static string GetRandomString(int length, bool isCapital = false)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder();

            int minRandomValue = isCapital ? (int)'A' : (int)'a';
            int maxRandomValue = minRandomValue + 25;
            char ch;

            for (int i = 0; i < length; i++)
            {
                ch = (char)rnd.Next(minRandomValue, maxRandomValue);
                sb.Append(ch);
            }

            return sb.ToString();
        }

        public static bool IsUnicodeCharacter(char c)
        {
            return UnicodeCharacters.Contains(c);
        }

        public static char ReplaceUnicodeCharacter(char c)
        {
            return ReplaceUnicodeCharacters[UnicodeCharacters.IndexOf(c)];
        }
    }
}
