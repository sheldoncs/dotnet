using AutoMapper;
using jwtcore.Data.Entities;
using jwtcore.Data.Entities.Dtos;

namespace Commanderjwtcore.Profiles {
    public class AdvisorProfile: Profile {
        public AdvisorProfile()
        {

            //CreateMap<TSource,TDestination>()' is obsolete

            
            //Create Target -> Source  (Client -> Databasase)
            CreateMap<AuthenticateCreateDto,Authentication>();
            
            CreateMap<Authentication,AuthenticateReadDto>();
        }
    }
}