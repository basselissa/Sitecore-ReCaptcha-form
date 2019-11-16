using System.Web;

namespace Sitecore.SharedSource.Forms.Fields.ReCaptcha.Services
{
    public class RecaptchaContext
    {
        private const string RecaptchaValidatedKey = "RecaptchaValidated";

        public static bool RecaptchaValidated
        {
            get
            {
                if (HttpContext.Current.Items.Contains(RecaptchaValidatedKey))
                {
                    return (bool) HttpContext.Current.Items[RecaptchaValidatedKey];
                }
                return false;
            }
            set => HttpContext.Current.Items[RecaptchaValidatedKey] = value;
        }
    }
}