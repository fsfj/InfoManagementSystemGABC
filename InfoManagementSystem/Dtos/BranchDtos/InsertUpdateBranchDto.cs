using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InfoManagementSystem.Dtos.BranchDtos
{
    public class InsertUpdateBranchDto
    {
        [Required]
        [Display(Name = "Branch Code")]
        public string Code { get; set; }
        [Display(Name = "Branch Name")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Barangay { get; set; }
        [Required]
        public string City { get; set; }
        [Display(Name ="Permit No.")]
        public string PermitNo { get; set; }
        [Display(Name = "Branch Manager")]
        public int? ManagerId { get; set; }
        [Display(Name = "Date Opened")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddThh:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? DateOpened { get; set; }
        public bool IsActive { get; set; }
    }
}