using Microsoft.EntityFrameworkCore;
using webApi.DataClasses;
using webApi.DataClasses.Entities;

namespace webApi.Services
{
    public class TestEntityService
    {
        private DataContext _context;
        public TestEntityService(DataContext context) {
            _context = context;
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
    }
}
