using Furion;
using System.Reflection;

namespace D.IdentityServer.Web.Entry;

public class SingleFilePublish : ISingleFilePublish
{
    public Assembly[] IncludeAssemblies()
    {
        return Array.Empty<Assembly>();
    }

    public string[] IncludeAssemblyNames()
    {
        return new[]
        {
            "D.IdentityServer.Application",
            "D.IdentityServer.Core",
            "D.IdentityServer.EntityFramework.Core",
            "D.IdentityServer.Web.Core"
        };
    }
}