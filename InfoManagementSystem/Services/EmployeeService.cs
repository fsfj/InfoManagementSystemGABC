using InfoManagementSystem.Dtos.EmployeeDtos;
using InfoManagementSystem.Repositories.Interfaces;
using InfoManagementSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace InfoManagementSystem.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository repo;
        public EmployeeService(IEmployeeRepository repo)
        {
            this.repo = repo;
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                await repo.Delete(id);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<GetEmployeeDto>> GetAll()
        {
            return await repo.GetAll();
        }

        public async Task<GetEmployeeDto> GetById(int id)
        {
            return await repo.GetById(id);
        }

        public async Task<bool> InsertUpdate(InsertUpdateEmployeeDto employee)
        {
            try
            {
                await repo.InsertUpdate(employee);

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}