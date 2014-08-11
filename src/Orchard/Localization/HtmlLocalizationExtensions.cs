using System.Globalization;
using System.Web.Mvc;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Aspects;
using Orchard.Mvc.Html;

namespace Orchard.Localization {
    public static class LocalizationExtensions {
        public static CultureInfo CurrentCultureInfo(this WorkContext workContext) {
            return CultureInfo.GetCultureInfo(workContext.CurrentCulture);
        }

        public static string GetTextDirection(this WorkContext workContext) {
            return workContext.GetTextDirection(null);
        }

        public static string GetTextDirection(this WorkContext workContext, IContent content) {
            var culture = workContext.CurrentSite.SiteCulture;
            if (content != null && content.Has<ILocalizableAspect>()) {
                culture = content.As<ILocalizableAspect>().Culture;
            }

            return CultureInfo.GetCultureInfo(culture).TextInfo.IsRightToLeft ? "rtl" : "ltr"; ;
        }
    }
}