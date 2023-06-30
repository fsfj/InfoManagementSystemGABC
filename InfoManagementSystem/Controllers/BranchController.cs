using InfoManagementSystem.Dtos;
using InfoManagementSystem.Dtos.BranchDtos;
using InfoManagementSystem.Services.Interfaces;
using InfoManagementSystem.ViewModels;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InfoManagementSystem.Controllers
{
    public class BranchController : Controller
    {
        private readonly IBranchService service;
        private readonly IEmployeeService empService;
        public BranchController(IBranchService service,
            IEmployeeService empService)
        {
            this.service = service;
            this.empService = empService;
        }
        // GET: Branch
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetData(JqueryDatatableDto param)
        {
            var sortColumnIndex = Convert.ToInt32(HttpContext.Request.QueryString["iSortCol_0"]);
            var sortDirection = HttpContext.Request.QueryString["sSortDir_0"];

            string orderBy = "Code";
            
            if(sortColumnIndex == 0)
            {
                orderBy = "Code";
            }
            else if(sortColumnIndex == 1)
            {
                orderBy = "Name";
            }else if(sortColumnIndex == 2)
            {
                orderBy = "BranchManager";
            }
            else if (sortColumnIndex == 3)
            {
                orderBy = "DateOpened";
            }

            var paginationDto = new PaginationDto
            {
                PageSize = param.iDisplayLength,
                PageNumber = param.iDisplayStart / param.iDisplayLength + 1,
                SearchQuery = param.sSearch,
                Sort = sortDirection,
                OrderBy = orderBy
            };

            var results = await service.Pagination(paginationDto);

            var totalRecords = results.Count() > 0 ? results.FirstOrDefault().TotalRecords : 0;

            foreach (var item in results)
            {
                item.Actions = "<a class='btn btn-primary' href='" + this.Url.Action("Edit", "Branch", new { Code = item.Code }) + "'>Edit</a> &nbsp;" +
                    "<a class='btn btn-danger' href='" + this.Url.Action("Delete", "Branch", new { Code = item.Code }) + "'>Delete</a>";
            }

            return Json(new
            {
                param.sEcho,
                iTotalRecords = totalRecords,
                iTotalDisplayRecords = totalRecords,
                aaData = results.ToList()
            }, JsonRequestBehavior.AllowGet);

        }

        public async Task<ActionResult> Create()
        {
            var vm = new InsertUpdateBranchVM();

            vm.Employees = (await empService.GetAll()).ToList();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InsertUpdateBranchDto dto)
        {
            if (ModelState.IsValid)
            {
                await service.InsertUpdate(dto);
                return RedirectToAction("Index");
            }
            var vm = new InsertUpdateBranchVM();

            vm.Employees = (await empService.GetAll()).ToList();
            return View(vm);
        }

        public async Task<ActionResult> Edit(string code)
        {
            var result = await service.GetByCode(code);
            if (result == null)
                return RedirectToAction("Index");

            var vm = new InsertUpdateBranchVM 
            {
                Address = result.Address,
                IsActive = result.IsActive,
                Barangay = result.Barangay,
                City = result.City,
                Code = result.Code,
                DateOpened = result.DateOpened,
                ManagerId = result.ManagerId,
                Name = result.Name,
                PermitNo = result.PermitNo
            };

            vm.Employees = (await empService.GetAll()).ToList();

            ViewBag.Employees = new SelectList((await empService.GetAll()).ToList(), "Id", "FullName", result.ManagerId.ToString());

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(InsertUpdateBranchDto dto)
        {
            if (ModelState.IsValid)
            {
                await service.InsertUpdate(dto);

                return RedirectToAction("Index");
            }
            var vm = new InsertUpdateBranchVM();

            vm.Employees = (await empService.GetAll()).ToList();

            ViewBag.Employees = new SelectList((await empService.GetAll()).ToList(), "Id", "FullName");
            return View(vm);
        }

        public async Task<ActionResult> Delete(string code)
        {
            if (code == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var branch = await service.GetByCode(code);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string code)
        {
            var branch = await service.GetByCode(code);

            await service.Delete(code);

            return RedirectToAction("Index");
        }
    }
}