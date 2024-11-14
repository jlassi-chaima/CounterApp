using Domain.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Serilog;



namespace Infrastructure.DataAccess.Repositories
{
    public class CounterRepository : ICounterRepository
    {
        private readonly CounterDbContext _context;
  
        public CounterRepository(CounterDbContext context)
        {
            _context = context;

        }
        public async Task AddAsync(Counter entity)
        {
            try
            {
                _context.Counters.Add(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                Log.Error(string.Format("Unexpected error creating counter .Database operation failed.Error: {0}", ex.Message));
                throw new Exception(string.Format("Unexpected error creating counter .Database operation failed.Error: {0}", ex.Message));
            }
        }

        public async Task<List<Counter>> GetAllAsync()
        {
            try
            {

                return await _context.Counters.ToListAsync();
            }

            catch (Exception ex)
            {
                Log.Error(string.Format("An unexpected error occurred during getting Counter.Database operation failed.Error: {0}", ex.Message));
                throw new Exception(string.Format("An unexpected error occurred during getting Counter.Database operation failed.Error: {0}", ex.Message));
            }
        }
    }
}
