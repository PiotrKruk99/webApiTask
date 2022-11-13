namespace webApi.DataClasses.Entities;

public class BookCl
{
    public int WriterId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int? YearOfPublication { get; set; }

    // public BookDto(string title, int? yearOfPublication = null)
    // {
    //     this.Title = title;
    //     this.YearOfPublication = yearOfPublication;
    // }
}
