using InfoManagementSystem.Dtos;
using InfoManagementSystem.Dtos.BranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoManagementSystem.Services.Interfaces
{
    public interface IBranchService
    {
        Task<IEnumerable<GetBranchDto>> Pagination(PaginationDto dto);
        Task<IEnumerable<GetBranchDto>> GetAll();
        Task<GetBranchDto> GetByCode(string code);
        Task<bool> Delete(string code);
        Task<bool> InsertUpdate(InsertUpdateBranchDto dto);
    }
}
