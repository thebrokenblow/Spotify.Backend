using AutoMapper;
using Spotify.Application.Common.Mappings;
using Spotify.Application.Groups.Commands.CreateGroup;

namespace Spotify.WebApi.Models;

public class CreateGroupDto : IMapWith<CreateGroupCommand>
{
    public string Title { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateGroupDto, CreateGroupCommand>()
            .ForMember(groupCommand => groupCommand.Title,
                opt => opt.MapFrom(noteDto => noteDto.Title))
            .ForMember(groupCommand => groupCommand.Description,
                opt => opt.MapFrom(groupDto => groupDto.Description));
    }
}