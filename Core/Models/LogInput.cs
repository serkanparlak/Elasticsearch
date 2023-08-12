namespace Core.Models;
public class LogInput {
    public required string Message { get; set;}
    public required string Level { get; set;}
    public required string Application { get; set; }
}