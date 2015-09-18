using AutoMapper;
using Fleetmatics.Domain;
using Fleetmatics.OauthApi.ViewModel;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fleetmatics.OauthApi.Mapper.DomainToViewModel
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<UserInformationViewModel, UserInformation>();
            AutoMapper.Mapper.CreateMap<UserInformationViewModel, IdentityUser>();
        }
    }
}