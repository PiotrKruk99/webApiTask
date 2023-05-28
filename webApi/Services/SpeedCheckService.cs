using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using webApi.DataClasses;
using webApi.DataClasses.Entities;

namespace webApi.Services;

public class SpeedCheckService : ISpeedCheckService
{
    private readonly DataContext _context;

    public SpeedCheckService(DataContext context)
    {
        _context = context;
    }

    public async Task<int> FillDatabase(int count)
    {
        try
        {
            _context.TestAutoEntities.RemoveRange(_context.TestAutoEntities);
            await _context.SaveChangesAsync();

            for (int i = 0; i < count; i++)
            {
                await _context.TestAutoEntities.AddAsync(new TestEntityThree());
            }

            await _context.SaveChangesAsync();

            return _context.TestAutoEntities.Count();
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public async Task<List<TestEntityThree>> GetAsync(int startIndex, int count)
    {
        try
        {
            await Task.CompletedTask; //only for async

            List<TestEntityThree> result = new List<TestEntityThree>();

            for (int i = startIndex; i < startIndex + count; i++)
            {
                var entity = _context.TestAutoEntities.SingleOrDefault(x => x.Id == i);

                if (entity is not null)
                    result.Add(entity);
            }

            return result;
        }
        catch (Exception)
        {
            return new List<TestEntityThree>();
        }
    }

    public async Task<TimeSpan> ExcecutionTimeTest(bool isCompiledTest)
    {
        var tempList = new List<TestEntityThree>();
        var count = _context.TestAutoEntities.Count();

        if (count <= 0)
            throw new Exception("Fill test table first.");

        var startIndex = _context.TestAutoEntities.First().Id;

        var watch = Stopwatch.StartNew();

        if (isCompiledTest)
        {
            for (int i = startIndex; i < startIndex + count; i++)
            {
                tempList.Add(await GetCompiled(i));
            }
        }
        else
        {
            for (int i = startIndex; i < startIndex + count; i++)
            {
                tempList.Add(await GetNotCompiled(i));
            }
        }

        return watch.Elapsed;
    }

    private async Task<TestEntityThree> GetNotCompiled(int index)
    {
        await Task.CompletedTask; //only for async

        var result = _context.TestAutoEntities.SingleOrDefault(x => x.Id == index);

        if (result is null)
            throw new Exception($"index {index} not exists in database");

        return result;
    }

    private readonly static Func<DataContext, int, Task<TestEntityThree?>> _getCompiled =
        EF.CompileAsyncQuery((DataContext context, int index) => context.TestAutoEntities
                                                                        .SingleOrDefault(x => x.Id == index));

    private async Task<TestEntityThree> GetCompiled(int index)
    {
        var result = await _getCompiled(_context, index);

        if (result is null)
            throw new Exception($"index {index} not exists in database");

        return result;
    }
}