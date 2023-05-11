using webApi.DataClasses.Entities;

namespace webApi.Services
{
    public interface ITestEntityService : IService
    {
        Task AddTestEtity(TestEntityOne entity);
        Task<int> AllowedMethodsTest(int id);
        Task<List<TestEntityOne>> GetTestEntities();
        public Task<List<TestEntityOne>> MethodInMethod();
        public Task<int> MethodsManyTimes();
    }
}