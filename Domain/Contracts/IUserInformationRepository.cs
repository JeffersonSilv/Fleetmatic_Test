
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;


namespace Fleetmatics.Domain.Contracts
{
    public interface IUserInformationRepository : IRepository<UserInformation>
    {
        Task<IdentityResult> Register(UserInformation entity);
        Task<UserInformation> FindUser(string userName, string password);
    }
}
