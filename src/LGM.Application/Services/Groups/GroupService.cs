using AutoMapper;
using LGM.Adapter.Repositories.Groups;
using LGM.Adapter.Services.Groups;
using LGM.Application.Exceptions.Validations;
using LGM.Domain.ValueObjects.Groups;
using LGM.DTOS.Groups;

namespace LGM.Application.Services.Groups;
public sealed class GroupService : IGroupService
{
    private readonly IMapper _mapper;
    private readonly IGroupRepository _groupRepository;

    public GroupService(IMapper mapper, IGroupRepository groupRepository)
    {
        _mapper = mapper;
        _groupRepository = groupRepository;
    }

    public async Task<GroupDto> InsertAsync(InsertGroupDto insertGroupDto)
    {
        var groupIdentity = _mapper.Map<GroupIdentity>(insertGroupDto.GroupIdentityDto);
        var @group = await _groupRepository.GetBySourceAsync(groupIdentity);

        if (@group != null)
        {
            throw new ValidationException("Já existe um grupo com essa identidade de origem!");
        }

        @group = new(insertGroupDto.Description, groupIdentity);

        await _groupRepository.InsertAsync(@group);
        return _mapper.Map<GroupDto>(@group);
    }
}