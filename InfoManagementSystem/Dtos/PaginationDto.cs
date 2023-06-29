using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InfoManagementSystem.Dtos
{
    public class PaginationDto
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string SearchQuery { get; set; }
        public string OrderBy { get; set; }
        public string Sort { get; set; }
    }
}