using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;

namespace D.IdentityServer.EntityFramework.Core;

[AppDbContext("D.IdentityServer", DbProvider.Sqlite)]
public class DefaultDbContext : AppDbContext<DefaultDbContext>
{
    public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
    {
    }
}
