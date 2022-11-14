using webApi.DataClasses;
using webApi.DataClasses.Entities;
using AutoMapper;

namespace webApi.Services;

public class BooksService
{
    private DataContext dataContext;
    private Mapper mapper;

    public BooksService()
    {
        dataContext = new DataContext();

        var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<BookCl, Book>()
                );
        mapper = new Mapper(config);
    }

    public async Task<bool> AddBook(BookCl bookCl)
    {
        Book book = mapper.Map<Book>(bookCl);

        dataContext.Books.Add(book);

        try
        {
            var result = await dataContext.SaveChangesAsync();
            return result == 0 ? false : true;
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.ToString());
            return false;
        }
    }

    public Book[] GetBooks()
    {
        Book[] books = dataContext.Books.ToArray();
        return books;
    }

    public async Task<bool> DeleteBook(int id)
    {
        var book = dataContext.Books.Find(id);

        if (book == null)
            return false;

        try
        {
            dataContext.Remove(book);
            await dataContext.SaveChangesAsync();
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.ToString());
            return false;
        }

        return true;
    }

    public async Task<bool> DeleteBooksByWriter(int id)
    {
        IEnumerable<Book> books = dataContext.Books.ToList().Where(x => x.WriterId == id);

        foreach (var book in books)
        {
            dataContext.Remove(book);
        }

        try
        {
            await dataContext.SaveChangesAsync();
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.ToString());
            return false;
        }

        return true;
    }
}