using webApi.DataClasses.Entities;

namespace webApi.Services;

public interface IBooksService : IService
{
    Task<bool> AddBook(BookCl bookCl);
    Book[] GetBooks();
    Task<bool> DeleteBook(int id);
    Task<bool> DeleteBooksByWriter(int id);
    Task<bool> UpdateBook(Book book);
}