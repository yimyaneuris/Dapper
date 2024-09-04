namespace DapperBeginners.Models;

public class VideoGame
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string? Publisher { get; set; }
    public string? Developer { get; set; }
    public DateTime ReleaseDate { get; set; }
}