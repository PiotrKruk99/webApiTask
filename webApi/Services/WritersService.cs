using webApi.DataClasses;
using webApi.DataClasses.Entities;
using AutoMapper;

namespace webApi.Services;

public class WritersService : IWritersService
{
    private readonly DataContext _dataContext;
    private readonly IBooksService _booksService;
    private readonly Mapper _mapper;

    public WritersService(IBooksService booksService, DataContext context)
    {
        _dataContext = context;
        _booksService = booksService;

        var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<WriterCl, Writer>()
                );
        _mapper = new Mapper(config);
    }

    private bool IsFullNameExists(string name)
    {
        return _dataContext.Writers.ToList().Exists(w => w.FullName.ToUpper().Equals(name.ToUpper()));
    }

    public async Task<bool> AddWriter(WriterCl writerCl)
    {
        Writer writer = _mapper.Map<Writer>(writerCl);

        if (IsFullNameExists(writer.FullName))
            return false;

        _dataContext.Writers.Add(writer);

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

    public async Task<bool> DeleteWriter(int id)
    {
        var writer = await _dataContext.Writers.FindAsync(id);

        if (writer is null)
            return false;

        try
        {
            _dataContext.Remove(writer);
            await _dataContext.SaveChangesAsync();
        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.ToString());
            return false;
        }

        var result = await _booksService.DeleteBooksByWriter(id);

        return result;
    }

    public async Task<Writer?> GetWriters(int id)
    {
        var writer = await _dataContext.FindAsync<Writer>(id);

        return writer;
    }

    public Writer[] GetWriters()
    {
        Writer[] writers = _dataContext.Writers.ToArray();
        return writers;
    }

    public Writer[] GetWriters(string name)
    {
        Writer[] writers = _dataContext.Writers
            .Where(x => x.FullName.ToUpper().Contains(name.ToUpper()))
            .ToArray();

        return writers;
    }

    public async Task<bool> UpdateWriter(Writer writer)
    {
        try
        {
            _dataContext.Writers.Update(writer);
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
