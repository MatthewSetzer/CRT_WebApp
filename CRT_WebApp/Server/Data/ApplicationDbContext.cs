using CRT_WebApp.Server.Models;
using CRT_WebApp.Shared;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CRT_WebApp.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<QuoteModel> Quotes { get; set; }
        public DbSet<SubGroupModel> SubGroups { get; set; }
        public DbSet<ApplicationUser> AppUsers { get; set; }
        public DbSet<ImageModel> Images { get; set; }
        public DbSet<NoteModel> Notes { get; set; }
        public DbSet<AssemblyItemModel> AssemblyItems { get; set; }
    }
}
