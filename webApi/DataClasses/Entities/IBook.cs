namespace webApi.DataClasses.Entities;

public interface IBook
{
    int BookId { get; set; }
    int WriterId { get; set; }
    string Title { get; set; }
    int? YearOfPublication { get; set; }
    string Genre { get; set; }
}
