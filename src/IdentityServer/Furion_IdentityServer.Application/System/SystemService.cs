using Furion.DependencyInjection;
using Furion.DynamicApiController;
using Microsoft.AspNetCore.Authorization;

namespace Furion_IdentityServer.Application
{
    /// <summary>
    /// Controller注释
    /// </summary>
    [DynamicApiController]
    [AppAuthorize]
    public class SystemService : ISystemService, ITransient
    {
        /// <summary>
        /// Action注释
        /// </summary>
        /// <returns></returns>
        public string GetDescription()
        {
            return "让 .NET 开发更简单，更通用，更流行。";
        }
    }
}