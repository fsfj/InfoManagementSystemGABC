using Dapper;
using InfoManagementSystem.Data;
using InfoManagementSystem.Dtos.EmployeeDtos;
using InfoManagementSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InfoManagementSystem.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IConnectionFactory connectionFactory;
        public EmployeeRepository(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public async Task Delete(int id)
        {
            using (var conn = connectionFactory.DatabaseConnection())
            {
                await conn.ExecuteAsync("usp_Employees_Delete", new { id }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<GetEmployeeDto>> GetAll()
        {
            using (var conn = connectionFactory.DatabaseConnection())
            {
                return await conn.QueryAsync<GetEmployeeDto>("usp_Employees_GetAll", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<GetEmployeeDto> GetById(int id)
        {
            using (var conn = connectionFactory.DatabaseConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<GetEmployeeDto>("usp_Employees_GetById", new {  id }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task InsertUpdate(InsertUpdateEmployeeDto emp)
        {
            using (var conn = connectionFactory.DatabaseConnection())
            {
                await conn.ExecuteAsync("usp_Employees_InsertUpdate", 
                    new { Id = emp.Id, FirstName = emp.FirstName, MiddleName = emp.MiddleName, LastName = emp.LastName, DateHired = emp.DateHired, Image = emp.Image  },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}