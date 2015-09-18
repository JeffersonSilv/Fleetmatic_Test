
using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fleetmatics.Domain
{
    public class UserInformation : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
