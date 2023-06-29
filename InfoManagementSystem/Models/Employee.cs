using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InfoManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Hired")]
        public DateTime? DateHired { get; set; }

        public byte[] Image { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [NotMapped]
        public string ImageStrings
        {
            get
            {
                if (Image == null) return "";
                return Convert.ToBase64String(Image);
            }
        }
    }
}