using System.Data.Entity;
using Fleetmatics.Data.Mapping;
using Fleetmatics.Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fleetmatics.Data.DataContexts
{
    public class OauthContext : IdentityDbContext<UserInformation>
    {
        public OauthContext()
            : base("Fleetmatics")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserInformationMapper());
            base.OnModelCreating(modelBuilder);
        }
    }
}
