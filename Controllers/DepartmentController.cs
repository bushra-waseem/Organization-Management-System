using Dapper_Company.Models;
using Dapper_Company.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Company.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public DepartmentController(
            IDepartmentRepository departmentRepository,
            IOrganizationRepository organizationRepository)
        {
            _departmentRepository = departmentRepository;
            _organizationRepository = organizationRepository;
        }

        // ⭐ MAIN PAGE (only if direct navigation needed)
        public async Task<IActionResult> Index()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return View(departments);
        }

        // ***** LOAD TABLE LIST (AJAX) *****
        public async Task<IActionResult> List()
        {
            var departments = await _departmentRepository.GetAllAsync();
            return PartialView("~/Views/Department/Index.cshtml", departments);
        }

        // ================= CREATE =================

        // GET
        public async Task<IActionResult> Create()
        {
            ViewBag.Organizations = await _organizationRepository.GetAllAsync();
            return PartialView("~/Views/Department/Create.cshtml");
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            await _departmentRepository.AddAsync(department);
            return Json(new { success = true });
        }

        // ================= EDIT =================

        // GET
        public async Task<IActionResult> Edit(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null) return NotFound();

            ViewBag.Organizations = await _organizationRepository.GetAllAsync();
            return PartialView("~/Views/Department/Edit.cshtml", department);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Department model)
        {
            await _departmentRepository.UpdateAsync(model);
            return Json(new { success = true });
        }

        // ================= DELETE =================

        // GET
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var department = await _departmentRepository.GetByIdAsync(id);
            if (department == null) return NotFound();

            return PartialView("~/Views/Department/Delete.cshtml", department);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _departmentRepository.DeleteAsync(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
    }
}
