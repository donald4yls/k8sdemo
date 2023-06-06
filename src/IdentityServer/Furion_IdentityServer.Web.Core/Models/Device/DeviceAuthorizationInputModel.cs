using Furion_IdentityServer.Web.Core.Models.Consent;

namespace Furion_IdentityServer.Web.Core.Models.Device
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; set; }
    }
}