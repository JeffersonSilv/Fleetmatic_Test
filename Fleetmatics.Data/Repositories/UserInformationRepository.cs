using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fleetmatics.Data.DataContexts;
using Fleetmatics.Domain;
using Fleetmatics.Domain.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fleetmatics.Data.Repositories
{
    public class UserInformationRepository : IUserInformationRepository
    {
        private readonly UserManager<UserInformation> _userManager;

        public UserInformationRepository()
        {
            var context = new OauthContext();
            _userManager = new UserManager<UserInformation>(new UserStore<UserInformation>(context));
        }

        public ICollection<UserInformation> Get()
        {
            return _userManager.Users.ToList();
        }

        public async Task<UserInformation> Get(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            return user;
        }
        
        public async Task<bool> SaveOrUpdate(UserInformation entity)
        {
            var result = await _userManager.CreateAsync(entity);

            return result.Succeeded;
        }
        
        public void Delete(UserInformation entity)
        {
            _userManager.Delete(entity);
        }

        public async Task<IdentityResult> Register(UserInformation entity)
        {
            var result = await _userManager.CreateAsync(entity, entity.Password);

            return result;
        }

        public async Task<UserInformation> FindUser(string userName, string password)
        {
            var result = await _userManager.FindAsync(userName, password);

            return result;
        }
    }
}