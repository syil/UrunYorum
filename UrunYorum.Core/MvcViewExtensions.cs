using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using UrunYorum.Data.Contractor;
using UrunYorum.Base.Enums;
using UrunYorum.Base;
using UrunYorum.Base.Utilities;
using UrunYorum.Data.Entities;
using System.Web.WebPages;
using UrunYorum.Base.Interfaces;

namespace UrunYorum.Core
{
    public static class MvcViewExtensions
    {
        //private static RouteMapDataService routeMapDataService;
        private static IConfigurationManager configurationManager;

        static MvcViewExtensions()
        {
            //routeMapDataService = routeMapService;
            configurationManager = new FileConfigurationManager();
        }

        public static MvcHtmlString CreateLink(this HtmlHelper htmlHelper, string text, LinkType linkType, object htmlAttributes = null, params object[] args)
        {
            string urlPattern = null;
            string anchorHtml, url;

            switch (linkType)
            {
                case LinkType.CategoryDetail:
                    urlPattern = configurationManager.GetConfigValue(SystemConstants.CategoryLinkPatternConfigKey) as string;
                    break;
                case LinkType.ProductDetail:
                    urlPattern = configurationManager.GetConfigValue(SystemConstants.ProductLinkPatternConfigKey) as string;
                    break;
                case LinkType.ManufacturerDetail:
                    urlPattern = configurationManager.GetConfigValue(SystemConstants.ManufacturerLinkPatternConfigKey) as string;
                    break;
                case LinkType.ReviewReadMore:
                    urlPattern = configurationManager.GetConfigValue(SystemConstants.ReviewReadMorePatternConfigKey) as string;
                    break;
            }

            if (!string.IsNullOrEmpty(urlPattern))
            {
                url = urlPattern.FormatWith(args);
                anchorHtml = SystemConstants.AnchorTemplate.FormatWith(url, text, "");
            }
            else
            {
                anchorHtml = "";
            }

            return new MvcHtmlString(anchorHtml);
        }

        public static void SetTitle(this WebViewPage webViewPage, string title)
        {
            string titlePattern = configurationManager.GetConfigValue(SystemConstants.SiteTitleConfigKey) as string;

            if (!string.IsNullOrEmpty(titlePattern))
            {
                webViewPage.ViewBag.Title = titlePattern.FormatWith(title);
            }
            else
            {
                webViewPage.ViewBag.Title = title;
            }
        }

        public static void SetTitle(this WebViewPage webViewPage, string format, params object[] args)
        {
            SetTitle(webViewPage, format.FormatWith(args));
        }
    }
}
