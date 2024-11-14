using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICounterRepository
    {
        Task AddAsync(Counter entity);
        Task<List<Counter>> GetAllAsync();

    }
}
