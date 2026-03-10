using System.Data;
using Dapper;
using Dapper_Company.Data;
using Dapper_Company.Models;
using Microsoft.Data.SqlClient;

namespace Dapper_Company.Repositories
{
    public class PositionRepository : IPositionRepository
    {
        private readonly DapperContext _context;

        public PositionRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Position>> GetAllAsync()
        {
            var query = @"SELECT p.Id, p.Name, p.DepartmentId, d.Name AS DepartmentName 
                           FROM Position p 
                           INNER JOIN Department d ON p.DepartmentId = d.Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Position>(query);
            }
        }

        public async Task<Position> GetByIdAsync(int id)
        {
            var query = @"SELECT p.Id, p.Name, p.DepartmentId, d.Name AS DepartmentName 
                           FROM Position p 
                           INNER JOIN Department d ON p.DepartmentId = d.Id 
                           WHERE p.Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Position>(query, new { Id = id });
            }
        }

        public async Task<int> AddAsync(Position position)
        {
            var query = @"INSERT INTO Position (Name, DepartmentId) VALUES (@Name, @DepartmentId);
                           SELECT CAST(SCOPE_IDENTITY() as int);";
            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleAsync<int>(query, position);
            }
        }

        public async Task<int> UpdateAsync(Position position)
        {
            var query = "UPDATE Position SET Name = @Name, DepartmentId = @DepartmentId WHERE Id = @Id";
            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(query, position);
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            //var query = "DELETE FROM Position WHERE Id = @Id";
            //using (var connection = _context.CreateConnection())
            //{
            //    return await connection.ExecuteAsync(query, new { Id = id });
            //}
            var query = "DELETE FROM Position WHERE Id = @Id";
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
                        throw new Exception("Cannot delete this Position because it has related Employee(s).");
                    }
                    throw;
                }
            }
        }
    }
}


