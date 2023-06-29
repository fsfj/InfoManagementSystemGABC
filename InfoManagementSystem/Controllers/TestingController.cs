using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InfoManagementSystem.Controllers
{
    public class TestingController : Controller
    {
        // GET: Testing
        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult List()
        //{
        //    var employees = await service.GetAll();

        //    //employees.ToList().ForEach(x => x.StartDateString = x.StartDate.ToString("dd'/'MM'/'yyyy"));

        //    if (!string.IsNullOrEmpty(param.sSearch))
        //    {
        //        employees = employees.Where(x => x.Name.ToLower().Contains(param.sSearch.ToLower())
        //                                      || x.Code.ToLower().Contains(param.sSearch.ToLower())
        //                                      || x.BranchManager.ToLower().Contains(param.sSearch.ToLower())
        //                                      || x.Address.ToString().Contains(param.sSearch.ToLower())
        //                                      || x.Barangay.ToString().Contains(param.sSearch.ToLower())
        //                                      || x.City.ToString().ToLower().Contains(param.sSearch.ToLower())).ToList();
        //    }

        //    var sortColumnIndex = Convert.ToInt32(HttpContext.Request.QueryString["iSortCol_0"]);
        //    var sortDirection = HttpContext.Request.QueryString["sSortDir_0"];

        //    var paginationDto = new PaginationDto
        //    {
        //        PageSize = param.iDisplayLength,
        //        PageNumber = param.iDisplayStart / param.iDisplayLength + 1,
        //        SearchQuery = param.sSearch,
        //        Sort = sortDirection,
        //        OrderBy = "Code"
        //    };

        //    var results = await service.Pagination(paginationDto);
        //    //if (sortColumnIndex == 3)
        //    //{
        //    //    employees = sortDirection == "asc" ? employees.OrderBy(c => c.Age) : employees.OrderByDescending(c => c.Age);
        //    //}
        //    //else if (sortColumnIndex == 4)
        //    //{
        //    //    employees = sortDirection == "asc" ? employees.OrderBy(c => c.StartDate) : employees.OrderByDescending(c => c.StartDate);
        //    //}
        //    //else if (sortColumnIndex == 5)
        //    //{
        //    //    employees = sortDirection == "asc" ? employees.OrderBy(c => c.Salary) : employees.OrderByDescending(c => c.Salary);
        //    //}
        //    //else
        //    //{
        //    //    Func<Employee, string> orderingFunction = e => sortColumnIndex == 0 ? e.Name :
        //    //                                                   sortColumnIndex == 1 ? e.Position :
        //    //                                                   e.Location;

        //    //    employees = sortDirection == "asc" ? employees.OrderBy(orderingFunction) : employees.OrderByDescending(orderingFunction);
        //    //}

        //    var displayResult = employees.Skip(param.iDisplayStart)
        //        .Take(param.iDisplayLength).ToList();
        //    var totalRecords = employees.Count();

        //    return Json(new
        //    {
        //        param.sEcho,
        //        iTotalRecords = totalRecords,
        //        iTotalDisplayRecords = totalRecords,
        //        aaData = displayResult
        //    }, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult Add(Employee emp)
        //{
        //    return Json(empDB.Add(emp), JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetbyID(int ID)
        //{
        //    var Employee = empDB.ListAll().Find(x => x.EmployeeID.Equals(ID));
        //    return Json(Employee, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult Update(Employee emp)
        //{
        //    return Json(empDB.Update(emp), JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult Delete(int ID)
        //{
        //    return Json(empDB.Delete(ID), JsonRequestBehavior.AllowGet);
        //}
    }
}