using AutoMapper;
using Spotify.Application.Common.Mappings;
using Spotify.Application.Groups.Commands.UpdateGroup;

namespace Spotify.WebApi.Models;

public class UpdateGroupDto : IMapWith<UpdateGroupCommand>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateGroupDto, UpdateGroupCommand>()
            .ForMember(groupCommand => groupCommand.Id,
                opt => opt.MapFrom(noteDto => noteDto.Id))
            .ForMember(groupCommand => groupCommand.Title,
                opt => opt.MapFrom(groupDto => groupDto.Title))
            .ForMember(groupCommand => groupCommand.Description,
                opt => opt.MapFrom(groupDto => groupDto.Description));
    }
}