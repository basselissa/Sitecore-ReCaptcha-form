using Sitecore.Mvc.Helpers;

namespace Sitecore.SharedSource.Forms.Fields.ReCaptcha.Views
{
    public static class HtmlHelper
    {
        public static bool IsExperienceFormsEditMode(this SitecoreHelper helper)
        {
            return Sitecore.Context.Request.QueryString["sc_formmode"] != null;
        }
    }
}