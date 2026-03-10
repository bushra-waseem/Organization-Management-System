using Dapper_Company.Models;

namespace Dapper_Company.Repositories
{
    public interface IPositionRepository
    {
        Task<IEnumerable<Position>> GetAllAsync();
        Task<Position> GetByIdAsync(int id);
        Task<int> AddAsync(Position position);
        Task<int> UpdateAsync(Position position);
        Task<int> DeleteAsync(int id);
    }
}
