namespace webApi.DataClasses.Entities;

public interface IBookCl
{
    int? WriterId { get; set; }
    string? Title { get; set; }
    int? YearOfPublication { get; set; }
    string? Genre { get; set; }
}
