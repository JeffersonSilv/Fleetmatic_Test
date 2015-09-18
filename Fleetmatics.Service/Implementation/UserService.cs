using System;
using System.Threading.Tasks;
using Fleetmatics.Data.Repositories;
using Fleetmatics.Domain;
using Fleetmatics.Domain.Contracts;
using Fleetmatics.Service.Contracts;

namespace Fleetmatics.Service.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserInformationRepository _userInformationRepository;

        public UserService()
        {
            _userInformationRepository = new UserInformationRepository();
        }
        public UserService(IUserInformationRepository userInformationRepository)
        {
            _userInformationRepository = userInformationRepository;
        }

        public async Task<UserInformation> RegisterUser(UserInformation userInformation)
        {
            try
            {
                var identityResult = await _userInformationRepository.Register(userInformation);

                if (!identityResult.Succeeded)
                    throw new Exception(string.Join("Error during user creation - {0}",
                        string.Join(",", identityResult.Errors)));
            }
            catch (Exception exception)
            {
                throw new Exception("Error during user creation", exception.InnerException);
            }

            return userInformation;
        }

        public Task<UserInformation> Authenticate(string userName, string password)
        {
            try
            {
                var user = _userInformationRepository.FindUser(userName, password);

                return user;
            }
            catch (Exception exception)
            {

                throw new Exception(string.Format("Error to find the user {0}", userName), exception.InnerException);
            }
        }
    }
}