using System.Data.Entity.ModelConfiguration;
using Fleetmatics.Domain;

namespace Fleetmatics.Data.Mappings
{
    public class UserInformationMapper : EntityTypeConfiguration<UserInformation>
    {
        public UserInformationMapper()
        {
            HasKey(k => k.Id);
            Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            Property(x => x.LastName).IsRequired().HasMaxLength(50);
            Property(x => x.RegistrationDate).IsRequired();
            Ignore(i => i.Password);
            Ignore(i => i.ConfirmPassword);
        }
    }
}