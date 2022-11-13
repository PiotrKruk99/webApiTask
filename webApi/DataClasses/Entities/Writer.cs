namespace webApi.DataClasses.Entities;

public class Writer
{
    public int WriterId { get; set; }
    public string FullName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Country { get; set; }

    public Writer(string fullName, DateTime dateOfBirth, string country)
    {
        this.FullName = fullName;
        this.DateOfBirth = dateOfBirth;
        this.Country = country;
    }

    public Writer()
    {
        this.FullName = string.Empty;
        this.Country = string.Empty;
    }
}
