using webApi.DataClasses.Entities;

namespace webApi.Services;

public interface IWritersService
{
    Task<bool> AddWriter(WriterCl writerCl);
    Task<bool> DeleteWriter(int id);
    Task<Writer?> GetWriters(int id);
    Writer[] GetWriters();
    Writer[] GetWriters(string name);
    Task<bool> UpdateWriter(Writer writer);
}
