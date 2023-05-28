using webApi.DataClasses.Entities;

namespace webApi.Services;

public interface ISpeedCheckService : IService
{
    Task<int> FillDatabase(int count);
    Task<List<TestEntityThree>> GetAsync(int startIndex, int count);
    Task<TimeSpan> ExcecutionTimeTest(bool isCompiledTest);
}