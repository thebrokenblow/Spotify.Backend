using AutoMapper;
using Spotify.Application.Common.Mappings;
using Spotify.Domain;

namespace Spotify.Application.Groups.Queries.GetGroupList;

public class GroupLookupDto : IMapWith<Group>
{
    public int Id { get; set; }
    public required string Title { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Group, GroupLookupDto>()
            .ForMember(group => group.Id,
                opt => opt.MapFrom(group => group.Id))
            .ForMember(group => group.Title,
                opt => opt.MapFrom(group => group.Title));
    }
}