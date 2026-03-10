using Dapper_Company.Models;
using Dapper_Company.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dapper_Company.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IPositionRepository _positionRepository;

        public EmployeeController(
            IEmployeeRepository employeeRepository,
            IOrganizationRepository organizationRepository,
            IDepartmentRepository departmentRepository,
            IPositionRepository positionRepository)
        {
            _employeeRepository = employeeRepository;
            _organizationRepository = organizationRepository;
            _departmentRepository = departmentRepository;
            _positionRepository = positionRepository;
        }

        // ⭐ MAIN PAGE
        public async Task<IActionResult> Index()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return View(employees);
        }

        // ⭐ LIST (AJAX)
        public async Task<IActionResult> List()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return PartialView("~/Views/Employee/Index.cshtml", employees);
        }

        // ================= CREATE =================

        public async Task<IActionResult> Create()
        {
            await LoadDropdowns();
            return PartialView("~/Views/Employee/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            await _employeeRepository.AddAsync(employee);
            return Json(new { success = true });
        }

        // ================= EDIT =================

        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null) return NotFound();

            await LoadDropdowns(employee);
            return PartialView("~/Views/Employee/Edit.cshtml", employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
            return Json(new { success = true });
        }

        // ================= DELETE =================

        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null) return NotFound();

            return PartialView("~/Views/Employee/Delete.cshtml", employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _employeeRepository.DeleteAsync(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // ================= HELPER =================
        private async Task LoadDropdowns(Employee? emp = null)
        {
            ViewBag.Organizations = new SelectList(
                await _organizationRepository.GetAllAsync(),
                "Id", "Name", emp?.OrganizationId);

            ViewBag.Departments = new SelectList(
                await _departmentRepository.GetAllAsync(),
                "Id", "Name", emp?.DepartmentId);

            ViewBag.Positions = new SelectList(
                await _positionRepository.GetAllAsync(),
                "Id", "Name", emp?.PositionId);
        }
    }
}
