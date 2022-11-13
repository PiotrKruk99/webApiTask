namespace webApi.DataClasses.Entities;

public class BookCl
{
    public int WriterId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int? YearOfPublication { get; set; }
    public string Genre { get; set; } = string.Empty;
}
