namespace webApi.DataClasses.Entities;

public class Writer
{
    public int WriterId { get; set; }
    public string FullName { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public Writer(string fullName, DateTime dateOfBirth)
    {
        this.FullName = fullName;
        this.DateOfBirth = dateOfBirth;
    }

    public Writer()
    {
        this.FullName = string.Empty;
    }
}
