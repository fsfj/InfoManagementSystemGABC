using InfoManagementSystem.Dtos;
using InfoManagementSystem.Dtos.BranchDtos;
using InfoManagementSystem.Repositories.Interfaces;
using InfoManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InfoManagementSystem.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository repo;
        public BranchService(IBranchRepository repo)
        {
            this.repo = repo;
        }

        public async Task<bool> Delete(string code)
        {
            try
            {
                await repo.Delete(code);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetBranchDto>> GetAll()
        {
            return await repo.GetAll();
        }

        public async Task<GetBranchDto> GetByCode(string code)
        {
            return await repo.GetByCode(code);
        }

        public async Task<bool> InsertUpdate(InsertUpdateBranchDto dto)
        {
            try
            {
                await repo.InsertUpdate(dto);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetBranchDto>> Pagination(PaginationDto dto)
        {
            var results = await repo.GetAll(dto);

            return results;
        }
    }
}