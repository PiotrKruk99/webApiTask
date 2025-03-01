﻿using Microsoft.EntityFrameworkCore;
using webApi.DataClasses;
using webApi.DataClasses.Entities;

namespace webApi.Services
{
    public class TestEntityService : ITestEntityService
    {
        private readonly DataContext _context;
        private readonly Lazy<ITestEntityService> _testEntity;
        private static int _counter;
        private static readonly List<string> _result = new List<string>();
        public TestEntityService(DataContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _testEntity = new Lazy<ITestEntityService>(() => serviceProvider.GetService<ITestEntityService>());
        }

        public async Task AddTestEtity(TestEntityOne entity)
        {
            try
            {
                await _context.EntityOnes.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        public async Task<List<TestEntityOne>> GetTestEntities()
        {
            return await _context.EntityOnes.Include(x => x.EntityTwo)
                                            .AsNoTracking()
                                            .ToListAsync();
        }

        private List<int> _testIds = new List<int>() { 1, 3 };

        private static readonly Func<DataContext, int, Task<int>> _allowedMethodsTest =
            EF.CompileAsyncQuery(
                (DataContext context, int id) => context.EntityOnes
                                                .AsNoTracking()
                                                .Where(x => x.Id == id)
                                                .Select(x => x.Id)
                                                .SingleOrDefault());

        public async Task<int> AllowedMethodsTest(int id)
        {
            return await _allowedMethodsTest(_context, id);
        }

        public async Task<List<TestEntityOne>> MethodInMethod()
        {
            return await _testEntity.Value.GetTestEntities();
        }

        public async Task<int> MethodsManyTimes()
        {
            if (_counter < 5)
            {
                var list = await _testEntity.Value.GetTestEntities();
                _result.Add(list[1].Value1);
                _counter++;
                await _testEntity.Value.MethodsManyTimes();
                return _counter;
            }
            else
            {
                return _counter;
            }
        }
    }
}
