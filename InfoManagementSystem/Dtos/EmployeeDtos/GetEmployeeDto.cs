using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoManagementSystem.Dtos.EmployeeDtos
{
    public class GetEmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {MiddleName} {LastName}";
            }
        }
        public DateTime? DateHired { get; set; }

        public byte[] Image { get; set; }
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