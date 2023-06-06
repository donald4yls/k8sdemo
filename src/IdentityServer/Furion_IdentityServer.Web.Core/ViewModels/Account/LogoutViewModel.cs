using Furion_IdentityServer.Web.Core.Models.Account;

namespace Furion_IdentityServer.Web.Core.ViewModels.Account
{
    public class LogoutViewModel : LogoutInputModel
    {
        public bool ShowLogoutPrompt { get; set; } = true;
    }
}
