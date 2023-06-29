using InfoManagementSystem.Dtos.BranchDtos;
using InfoManagementSystem.Dtos.EmployeeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoManagementSystem.ViewModels
{
    public class InsertUpdateBranchVM : InsertUpdateBranchDto
    {
        public List<GetEmployeeDto> Employees { get; set; }
    }
}