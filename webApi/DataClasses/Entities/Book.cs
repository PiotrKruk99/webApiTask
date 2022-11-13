namespace webApi.DataClasses.Entities;

public class Book
{
    public int BookId { get; set; }
    public int WriterId { get; set; }
    public string Title { get; set; }
    public int? YearOfPublication { get; set; }

    public Book(string title, int yearOfPublication)
    {
        this.Title = title;
        this.YearOfPublication = yearOfPublication;
    }

    public Book()
    {
        this.Title = string.Empty;
    }
}
