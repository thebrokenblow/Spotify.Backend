using Spotify.Domain;
using Spotify.Application.Common.Mappings;
using AutoMapper;

namespace Spotify.Application.Groups.Queries.GetGroupDetails;

public class GroupDetailsVM : IMapWith<Group>
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Group, GroupDetailsVM>()
            .ForMember(groupVM => groupVM.Title,
                        opt => opt.MapFrom(group => group.Title))
             .ForMember(groupVM => groupVM.Description,
                        opt => opt.MapFrom(group => group.Description));

    }
}