using Fleetmatics.OauthApi.Mapper.DomainToViewModel;
using Fleetmatics.OauthApi.Mapper.ViewModelToDomain;

namespace Fleetmatics.OauthApi.Mapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(init =>
            {
                init.AddProfile<DomainToViewModelMappingProfile>();
                init.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}