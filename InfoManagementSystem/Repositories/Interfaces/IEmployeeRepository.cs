using InfoManagementSystem.Dtos.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoManagementSystem.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<GetEmployeeDto>> GetAll();
        Task<GetEmployeeDto> GetById(int id);
        Task Delete(int id);
        Task InsertUpdate(InsertUpdateEmployeeDto employee);
    }
}
