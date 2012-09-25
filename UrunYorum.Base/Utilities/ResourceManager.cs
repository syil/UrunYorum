using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Base.Resources;
using UrunYorum.Base.Enums;
using System.Globalization;

namespace UrunYorum.Base.Utilities
{
    public class ResourceManager
    {
        private static CultureInfo currentCultureInfo;
        private static CultureInfo turkishCultureInfo;
        private static CultureInfo englishCultureInfo;
        private static SiteLanguage siteLanguage;

        public static SiteLanguage Language { get { return siteLanguage; } }

        /// <summary>
        /// Static Constructor
        /// </summary>
        static ResourceManager()
        {
            turkishCultureInfo = new CultureInfo("tr");
            englishCultureInfo = new CultureInfo("en");

            currentCultureInfo = CultureInfo.CurrentCulture;
        }

        public static void SetLanguage(SiteLanguage language)
        {
            siteLanguage = language;
            currentCultureInfo = new CultureInfo((int)language);
        }

        public static string GetString(string key)
        {
            string value = Strings.ResourceManager.GetString(key, currentCultureInfo);

            if (string.IsNullOrEmpty(value))
            {
                // TO DO: Log
                return string.Format("[{0}]", key);
            }
            else
            {
                return value;
            }
        }

        public static string GetString(string key, SiteLanguage language)
        {
            string value;

            switch (language)
            {
                case SiteLanguage.Turkish:
                    value = Strings.ResourceManager.GetString(key, turkishCultureInfo);
                    break;
                case SiteLanguage.English:
                default:
                    value = Strings.ResourceManager.GetString(key, englishCultureInfo);
                    break;
            }

            if (string.IsNullOrEmpty(value))
            {
                // TO DO: Log
                return string.Format("[{0}]", key);
            }
            else
            {
                return value;
            }
        }
    }
}
