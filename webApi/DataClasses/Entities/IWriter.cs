namespace webApi.DataClasses.Entities;

public interface IWriter
{
    int WriterId { get; set; }
    string FullName { get; set; }
    DateTime? DateOfBirth { get; set; }
    string Country { get; set; }
}
