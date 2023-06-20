using Microsoft.Extensions.Options;
using WebSite.EndPoint.Utilities.AppSettings.Models;

namespace WebSite.EndPoint.Utilities.AppSettings.Services
{
    public class WelcomeMessageService : IWelcomeMessageService
    {
        private readonly WelcomeMessageSettings _welcomeMessageSettings;

        public WelcomeMessageService(IOptions<WelcomeMessageSettings> welcomeMessageSettings)
        {
            _welcomeMessageSettings = welcomeMessageSettings.Value;
        }

        public string GetWelcomeMessage()
        {
            return _welcomeMessageSettings.Message;
        }
    }

}
