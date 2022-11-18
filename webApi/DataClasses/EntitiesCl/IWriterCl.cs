namespace webApi.DataClasses.Entities;

public interface IWriterCl
{
    string? FullName { get; set; }
    DateTime? DateOfBirth { get; set; }
    string? Country { get; set; }
}
