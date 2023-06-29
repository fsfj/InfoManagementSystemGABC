using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoManagementSystem.Dtos.BranchDtos
{
    public class GetBranchDto : PaginationResultDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string PermitNo { get; set; }
        public int? ManagerId { get; set; }
        public string BranchManager { get; set; }
        public DateTime? DateOpened { get; set; }
        public string DateOpenedStrings
        {
            get
            {
                if (DateOpened == null) return "";

                return DateOpened?.ToString("MM/dd/yyyy");
            }
        }
        public bool IsActive { get; set; }
        public string Actions { get; set; }
        //public string Actions
        //{
        //    get
        //    {
        //        return $"<a class='btn btn-primary' href='/Branch/Edit/{Code}'>Edit</a>&nbsp; " +
        //            $"<a class='btn btn-primary' href='/Branch/Edit/{Code}'>Edit</a>";

        //    }
        //}
    }
}