using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UrunYorum.Core
{
    public class SystemConstants
    {
        public const string ConnectionStringName = "UrunYorum.ConnectionString";
        public const string CategoryLinkPatternConfigKey = "UrunYorum.Web.RoutePatterns.CategoryLink";
        public const string ManufacturerLinkPatternConfigKey = "UrunYorum.Web.RoutePatterns.ManufacturerLink";
        public const string ProductLinkPatternConfigKey = "UrunYorum.Web.RoutePatterns.ProductLink";
        public const string SiteTitleConfigKey = "UrunYorum.Web.Pages.SiteTitle";
        public const string ReviewReadMorePatternConfigKey = "UrunYorum.Web.RoutePatterns.ReviewLink";

        /// <summary>
        /// <code>&lt;a href="{0}" {2}&gt;{1}&lt;/a&gt;</code>
        /// </summary>
        public const string AnchorTemplate = "<a href=\"{0}\" {2}>{1}</a>";
    }
}
