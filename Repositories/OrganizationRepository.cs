using System.Data;
using Dapper;
using Dapper_Company.Data;
using Dapper_Company.Models;
using Microsoft.Data.SqlClient;

namespace Dapper_Company.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly DapperContext _context;

        public OrganizationRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Organization>> GetAllAsync()
        {
            var query = "SELECT * FROM Organization";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Organization>(query);
            }
        }

        public async Task<Organization> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Organization WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Organization>(query, new { Id = id });
            }
        }

        public async Task<int> AddAsync(Organization organization)
        {
            var query = "INSERT INTO Organization (Name) VALUES (@Name); SELECT CAST(SCOPE_IDENTITY() as int);";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<int>(query, organization);
            }
        }

        public async Task<int> UpdateAsync(Organization organization)
        {
            var query = "UPDATE Organization SET Name = @Name WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, organization);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            //var query = "DELETE FROM Organization WHERE Id = @Id";
            //using (var connection = _context.CreateConnection())
            //{
            //    return await connection.ExecuteAsync(query, new { Id = id });
            //}
            var query = "DELETE FROM Organization WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                try
                {
                    return await connection.ExecuteAsync(query, new { Id = id });
                }
                catch (SqlException ex)
                {
                    if (ex.Message.Contains("REFERENCE constraint"))
                    {
                        throw new Exception("Cannot delete this Organization because it has related Departments.");
                    }
                    throw;
                }
            }
        }
    }
}