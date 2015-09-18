using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Fleetmatics.Domain;
using Fleetmatics.OauthApi.ViewModel;
using Fleetmatics.Service;
using Fleetmatics.Service.Contracts;
using Fleetmatics.Service.Implementation;

namespace Fleetmatics.OauthApi.Controllers
{
    public class AccountController : ApiController
    {
        private readonly IUserService _userService;

        public AccountController()
        {
            _userService = new UserService();
        }

        [AllowAnonymous]
        [Route("register")]
        public async Task<HttpResponseMessage> Register(UserInformationViewModel user)
        {
            HttpResponseMessage response;

            var userInformation = AutoMapper.Mapper.Map<UserInformationViewModel, UserInformation>(user);
            
            try
            {
                await _userService.RegisterUser(userInformation);
                response = Request.CreateResponse(HttpStatusCode.Created, user);
            }
            catch (Exception)
            {
                response = Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return response;
        }
    }
}
