using Dapper_Company.Models;

namespace Dapper_Company.Repositories
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task<Department> GetByIdAsync(int id);
        Task<int> AddAsync(Department department);
        Task<int> UpdateAsync(Department department);
        Task<int> DeleteAsync(int id);
    }
}
