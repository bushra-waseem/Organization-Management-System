using Dapper_Company.Models;
using Dapper_Company.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dapper_Company.Controllers
{
    public class PositionController : Controller
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public PositionController(
            IPositionRepository positionRepository,
            IDepartmentRepository departmentRepository)
        {
            _positionRepository = positionRepository;
            _departmentRepository = departmentRepository;
        }

        // ⭐ MAIN PAGE
        public async Task<IActionResult> Index()
        {
            var positions = await _positionRepository.GetAllAsync();
            return View(positions);
        }

        // ⭐ LIST (AJAX)
        public async Task<IActionResult> List()
        {
            var positions = await _positionRepository.GetAllAsync();
            return PartialView("~/Views/Position/Index.cshtml", positions);
        }

        // ================= CREATE =================

        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = new SelectList(
                await _departmentRepository.GetAllAsync(),
                "Id", "Name");

            return PartialView("~/Views/Position/Create.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Position position)
        {
            await _positionRepository.AddAsync(position);
            return Json(new { success = true });
        }

        // ================= EDIT =================

        public async Task<IActionResult> Edit(int id)
        {
            var position = await _positionRepository.GetByIdAsync(id);
            if (position == null) return NotFound();

            ViewBag.Departments = new SelectList(
                await _departmentRepository.GetAllAsync(),
                "Id", "Name", position.DepartmentId);

            return PartialView("~/Views/Position/Edit.cshtml", position);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Position position)
        {
            await _positionRepository.UpdateAsync(position);
            return Json(new { success = true });
        }

        // ================= DELETE =================

        public async Task<IActionResult> Delete(int id)
        {
            var position = await _positionRepository.GetByIdAsync(id);
            if (position == null) return NotFound();

            return PartialView("~/Views/Position/Delete.cshtml", position);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _positionRepository.DeleteAsync(id);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
