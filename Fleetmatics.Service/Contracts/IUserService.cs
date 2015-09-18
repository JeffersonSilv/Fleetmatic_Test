
using System.Threading.Tasks;
using Fleetmatics.Domain;

namespace Fleetmatics.Service.Contracts
{
    public interface IUserService
    {
        Task<UserInformation> RegisterUser(UserInformation userInformation);

        Task<UserInformation> Authenticate(string userName, string password);
    }
}
