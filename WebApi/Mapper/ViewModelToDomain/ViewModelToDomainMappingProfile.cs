
using AutoMapper;
using Fleetmatics.Domain;
using Fleetmatics.OauthApi.ViewModel;

namespace Fleetmatics.OauthApi.Mapper.ViewModelToDomain
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            AutoMapper.Mapper.CreateMap<UserInformation, UserInformationViewModel>();
        }
    }
}