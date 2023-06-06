using Furion_IdentityServer.Web.Core.ViewModels.Consent;

namespace Furion_IdentityServer.Web.Core.ViewModels.Device
{
    public class DeviceAuthorizationViewModel : ConsentViewModel
    {
        public string UserCode { get; set; }
        public bool ConfirmUserCode { get; set; }
    }
}