using Dapper;
using Dapper_Company.Data;
using Dapper_Company.Models;
using System.Data;

namespace Dapper_Company.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
        {
            private readonly DapperContext _context;

            public EmployeeRepository(DapperContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Employee>> GetAllAsync()
            {
                var query = @"SELECT e.Id, e.Name, e.Gender, e.Salary, 
                                 e.OrganizationId, o.Name AS OrganizationName,
                                 e.DepartmentId, d.Name AS DepartmentName,
                                 e.PositionId, p.Name AS PositionName
                          FROM Employee e
                          INNER JOIN Organization o ON e.OrganizationId = o.Id
                          INNER JOIN Department d ON e.DepartmentId = d.Id
                          INNER JOIN Position p ON e.PositionId = p.Id";

                using (var connection = _context.CreateConnection())
                {
                    return await connection.QueryAsync<Employee>(query);
                }
            }

            public async Task<Employee> GetByIdAsync(int id)
            {
                var query = @"SELECT e.Id, e.Name, e.Gender, e.Salary,
                                 e.OrganizationId, o.Name AS OrganizationName,
                                 e.DepartmentId, d.Name AS DepartmentName,
                                 e.PositionId, p.Name AS PositionName
                          FROM Employee e
                          INNER JOIN Organization o ON e.OrganizationId = o.Id
                          INNER JOIN Department d ON e.DepartmentId = d.Id
                          INNER JOIN Position p ON e.PositionId = p.Id
                          WHERE e.Id = @Id";

                using (var connection = _context.CreateConnection())
                {
                    return await connection.QuerySingleOrDefaultAsync<Employee>(query, new { Id = id });
                }
            }

            public async Task<int> AddAsync(Employee employee)
            {
                var query = @"INSERT INTO Employee (Name, Gender, Salary, OrganizationId, DepartmentId, PositionId)
                          VALUES (@Name, @Gender, @Salary, @OrganizationId, @DepartmentId, @PositionId)";

                using (var connection = _context.CreateConnection())
                {
                    return await connection.ExecuteAsync(query, employee);
                }
            }

            public async Task<int> UpdateAsync(Employee employee)
            {
                var query = @"UPDATE Employee 
                          SET Name = @Name, Gender = @Gender, Salary = @Salary,
                              OrganizationId = @OrganizationId, DepartmentId = @DepartmentId, PositionId = @PositionId
                          WHERE Id = @Id";

                using (var connection = _context.CreateConnection())
                {
                    return await connection.ExecuteAsync(query, employee);
                }
            }

            public async Task<int> DeleteAsync(int id)
            {
                var query = "DELETE FROM Employee WHERE Id = @Id";

                using (var connection = _context.CreateConnection())
                {
                    return await connection.ExecuteAsync(query, new { Id = id });
                }
            }
        }
}