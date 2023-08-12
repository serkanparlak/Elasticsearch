namespace Core.Models;

public class Log
{
    public required string Message { get; set; }
    public required string Application { get; set; }
    public required string Level { get; set; }
    public DateTime Timestamp  { get; set; }
}
