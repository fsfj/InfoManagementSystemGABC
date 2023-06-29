using InfoManagementSystem.Dtos.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoManagementSystem.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<GetEmployeeDto>> GetAll();
        Task<GetEmployeeDto> GetById(int id);
        Task<bool> Delete(int id);
        Task<bool> InsertUpdate(InsertUpdateEmployeeDto employee);
    }
}
