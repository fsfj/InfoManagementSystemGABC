using Dapper;
using InfoManagementSystem.Data;
using InfoManagementSystem.Dtos;
using InfoManagementSystem.Dtos.BranchDtos;
using InfoManagementSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InfoManagementSystem.Repositories
{
    public class BranchRepository : IBranchRepository
    {
        private readonly IConnectionFactory connectionFactory;
        public BranchRepository(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }
        public async Task Delete(string code)
        {
            using (var conn = connectionFactory.DatabaseConnection())
            {
                await conn.ExecuteAsync("usp_Branches_Delete", new { code }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<GetBranchDto>> GetAll(PaginationDto dto)
        {
            using (var conn = connectionFactory.DatabaseConnection())
            {
                return await conn.QueryAsync<GetBranchDto>("usp_Branches_Pagination", dto, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<GetBranchDto>> GetAll()
        {
            using (var conn = connectionFactory.DatabaseConnection())
            {
                return await conn.QueryAsync<GetBranchDto>("usp_Branches_GetAll", commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<GetBranchDto> GetByCode(string code)
        {
            using (var conn = connectionFactory.DatabaseConnection())
            {
                return await conn.QueryFirstOrDefaultAsync<GetBranchDto>("usp_Branches_GetByCode", new { code }, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task InsertUpdate(InsertUpdateBranchDto branch)
        {
            using (var conn = connectionFactory.DatabaseConnection())
            {
                await conn.ExecuteAsync("usp_Branches_InsertUpdate", branch,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}