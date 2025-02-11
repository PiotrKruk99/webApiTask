using webApi.DataClasses;
using webApi.DataClasses.Entities;
using AutoMapper;

namespace webApi.Services;

public class BooksService : IBooksService
{
    private readonly DataContext _dataContext;
    private readonly Mapper _mapper;

    public BooksService(DataContext context)
    {
        _dataContext = context;

        var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<BookCl, Book>()
                );
        _mapper = new Mapper(config);
    }

    private bool IsTitleExists(string title)
    {
        return _dataContext.Books.ToList().Exists(b => b.Title.ToUpper().Equals(title.ToUpper()));
    }

    public async Task<bool> AddBook(BookCl bookCl)
    {
        Book book = _mapper.Map<Book>(bookCl);

        if (IsTitleExists(book.Title))
            return false;

        var writer = _dataContext.Writers.FirstOrDefault(w => w.WriterId == book.WriterId);
        if (writer is null)
            return false;

        _dataContext.Books.Add(book);

        try
        {
            var result = await _dataContext.SaveChangesAsync();
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
        Book[] books = _dataContext.Books.ToArray();
        return books;
    }

    public async Task<bool> DeleteBook(int id)
    {
        var book = await _dataContext.Books.FindAsync(id);

        if (book == null)
            return false;

        try
        {
            _dataContext.Remove(book);
            await _dataContext.SaveChangesAsync();
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
        IEnumerable<Book> books = _dataContext.Books.Where(x => x.WriterId == id);
        // var query = dataContext.Books.Join(dataContext.Writers, b => b.WriterId, w => w.WriterId, (b, w)
        //         => new { WriterName = w.FullName, BookTitle = b.Title });

        if (!books.Any())
            return false;

        foreach (var book in books)
        {
            _dataContext.Remove(book);
        }

        try
        {
            await _dataContext.SaveChangesAsync();
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.ToString());
            return false;
        }

        return true;
    }

    public async Task<bool> UpdateBook(Book book)
    {
        try
        {
            _dataContext.Books.Update(book);
            await _dataContext.SaveChangesAsync();
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.ToString());
            return false;
        }

        return true;
    }
}