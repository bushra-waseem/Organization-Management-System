using System.Data;
using Dapper;
using Dapper_Company.Data;
using Dapper_Company.Models;
using Microsoft.Data.SqlClient;

namespace Dapper_Company.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
            private readonly DapperContext _context;

            public DepartmentRepository(DapperContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Department>> GetAllAsync()
            {
                var query = @"SELECT d.Id, d.Name, d.OrganizationId, o.Name AS OrganizationName 
                           FROM Department d 
                           INNER JOIN Organization o ON d.OrganizationId = o.Id";
                using (var connection = _context.CreateConnection())
                {
                    return await connection.QueryAsync<Department>(query);
                }
            }

            public async Task<Department> GetByIdAsync(int id)
            {
                var query = @"SELECT d.Id, d.Name, d.OrganizationId, o.Name AS OrganizationName 
                           FROM Department d 
                           INNER JOIN Organization o ON d.OrganizationId = o.Id 
                           WHERE d.Id = @Id";
                using (var connection = _context.CreateConnection())
                {
                    return await connection.QuerySingleOrDefaultAsync<Department>(query, new { Id = id });
                }
            }

            public async Task<int> AddAsync(Department department)
            {
                var query = @"INSERT INTO Department (Name, OrganizationId) VALUES (@Name, @OrganizationId);
                           SELECT CAST(SCOPE_IDENTITY() as int);";
                using (var connection = _context.CreateConnection())
                {
                    return await connection.QuerySingleAsync<int>(query, department);
                }
            }

            public async Task<int> UpdateAsync(Department department)
            {
                var query = "UPDATE Department SET Name = @Name, OrganizationId = @OrganizationId WHERE Id = @Id";
                using (var connection = _context.CreateConnection())
                {
                    return await connection.ExecuteAsync(query, department);
                }
            }

            public async Task<int> DeleteAsync(int id)
            {
            //var query = "DELETE FROM Department WHERE Id = @Id";
            //using (var connection = _context.CreateConnection())
            //{
            //    return await connection.ExecuteAsync(query, new { Id = id });
            //}

            var query = "DELETE FROM Department WHERE Id = @Id";
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
                        throw new Exception("Cannot delete this department because it has related positions.");
                    }
                    throw;
                }
            }
        }
        }
}