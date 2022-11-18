namespace webApi.DataClasses.Entities;

public class WriterCl : IWriterCl
{
    public string? FullName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? Country { get; set; }
}
