using System.Threading.Tasks;

namespace Sitecore.SharedSource.Forms.Fields.ReCaptcha.Services
{
    public interface IReCaptchaService
    {
        Task<bool> Verify(string response);
        bool VerifySync(string response);
    }
}
