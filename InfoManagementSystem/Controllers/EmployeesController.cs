using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InfoManagementSystem.Data;
using InfoManagementSystem.Models;
using System.IO;
using InfoManagementSystem.Repositories.Interfaces;
using InfoManagementSystem.Services.Interfaces;
using InfoManagementSystem.Dtos.EmployeeDtos;

namespace InfoManagementSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService service;
        public EmployeesController(IEmployeeService service)
        {
            this.service = service;
        }
        // GET: Employees
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> List()
        {
            var results = Json(await service.GetAll(), JsonRequestBehavior.AllowGet);
            results.MaxJsonLength = int.MaxValue;
            return results;
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetbyID(int id)
        {
            var employee = await service.GetById(id);
            return Json(employee, JsonRequestBehavior.AllowGet);
        }
       
        [HttpPost]
        public async Task<ActionResult> Add(InsertUpdateEmployeeDto emp)
        {

            if(emp.ImageFile != null)
            {
                MemoryStream target = new MemoryStream();
                emp.ImageFile.InputStream.CopyTo(target);
                byte[] data = target.ToArray();

                emp.Image = data;
               
            }
            var result = await service.InsertUpdate(emp);

            return Json(new { success = result }, JsonRequestBehavior.AllowGet);
        }


        [HttpPut]
        public async Task<ActionResult> Update(InsertUpdateEmployeeDto emp)
        {
            if(emp.ImageFile != null)
            {
                MemoryStream target = new MemoryStream();
                emp.ImageFile.InputStream.CopyTo(target);
                byte[] data = target.ToArray();

                emp.Image = data;
            }

            var result = await service.InsertUpdate(emp);
            return Json(new { success = result }, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await service.Delete(id);
            return Json(new { success = result }, JsonRequestBehavior.AllowGet);
        }
    }
}
