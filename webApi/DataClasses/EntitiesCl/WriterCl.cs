namespace webApi.DataClasses.Entities;

public class WriterCl
{
    public string FullName { get; set; } = string.Empty;
    public DateTime? DateOfBirth { get; set; }

    // public WriterDto(string fullName, DateTime? dateOfBirth = null)
    // {
    //     this.FullName = fullName;
    //     this.DateOfBirth = dateOfBirth;
    // }
}
