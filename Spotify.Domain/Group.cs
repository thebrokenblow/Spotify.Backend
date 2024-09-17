namespace Spotify.Domain;

public class Group
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
}