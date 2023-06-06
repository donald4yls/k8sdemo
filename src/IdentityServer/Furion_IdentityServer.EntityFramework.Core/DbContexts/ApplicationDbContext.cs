using Furion.DatabaseAccessor;
using Microsoft.EntityFrameworkCore;
using Furion_IdentityServer.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Furion_IdentityServer.EntityFramework.Core.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}