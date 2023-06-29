using InfoManagementSystem.Dtos;
using InfoManagementSystem.Dtos.BranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoManagementSystem.Repositories.Interfaces
{
    public interface IBranchRepository
    {
        Task<IEnumerable<GetBranchDto>> GetAll();
        Task<IEnumerable<GetBranchDto>> GetAll(PaginationDto dto);
        Task<GetBranchDto> GetByCode(string code);
        Task Delete(string code);
        Task InsertUpdate(InsertUpdateBranchDto branch);
    }
}
