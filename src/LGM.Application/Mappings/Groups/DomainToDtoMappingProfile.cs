using AutoMapper;
using LGM.Domain.Entities.Groups;
using LGM.Domain.ValueObjects.Groups;
using LGM.DTOS.Groups;

namespace LGM.Application.Mappings.Groups;
public sealed class DomainToDtoMappingProfile : Profile
{
    public DomainToDtoMappingProfile()
    {
        CreateMap<GroupIdentity, GroupIdentityDto>().ReverseMap();
        CreateMap<Group, GroupDto>();
    }

}

