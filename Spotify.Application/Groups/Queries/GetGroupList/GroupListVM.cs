namespace Spotify.Application.Groups.Queries.GetGroupList;

public class GroupListVM
{
    public required IList<GroupLookupDto> Groups { get; set; }
}