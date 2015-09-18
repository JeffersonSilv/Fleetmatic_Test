using System;

namespace Fleetmatics.OauthApi.ViewModel
{
    public class UserInformationViewModel
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public DateTime RegistrationDate
        {
            get
            {
                return DateTime.Now;
            }

        }
    }
}