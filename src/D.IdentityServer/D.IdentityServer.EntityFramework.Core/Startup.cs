using Furion;
using Microsoft.Extensions.DependencyInjection;

namespace D.IdentityServer.EntityFramework.Core;

public class Startup : AppStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDatabaseAccessor(options =>
        {
            options.AddDbPool<DefaultDbContext>();
        }, "D.IdentityServer.Database.Migrations");
    }
}
