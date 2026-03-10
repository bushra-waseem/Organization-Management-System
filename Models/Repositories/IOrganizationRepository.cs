using Dapper_Company.Models;

namespace Dapper_Company.Repositories
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<Organization>> GetAllAsync();
        Task<Organization> GetByIdAsync(int id);
        Task<int> AddAsync(Organization organization);
        Task<int> UpdateAsync(Organization organization);
        Task<int> DeleteAsync(int id);
    }
}

