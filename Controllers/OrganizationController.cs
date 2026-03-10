using Dapper_Company.Models;
using Dapper_Company.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Dapper_Company.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationController(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }
        // ⭐ MAIN PAGE
        public async Task<IActionResult> Index()
        {
            var organizations = await _organizationRepository.GetAllAsync();
            return View(organizations);
        }


        public IActionResult OrganizationList()
        {
            return View();
        }


        // ***** LOAD TABLE LIST *****
        public async Task<IActionResult> List()
        {
            var organizations = await _organizationRepository.GetAllAsync();
            return PartialView("~/Views/Organization/_OrganizationList.cshtml", organizations);
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return PartialView("~/Views/Organization/Create.cshtml");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Organization organization)
        {
            await _organizationRepository.AddAsync(organization);
            return Json(new { success = true });
        }

        // GET
        public async Task<IActionResult> Edit(int id)
        {
            var org = await _organizationRepository.GetByIdAsync(id);
            if (org == null) return NotFound();

            return PartialView(org);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Organization model)
        {
            await _organizationRepository.UpdateAsync(model);
            return Json(new { success = true });
        }

        // GET
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var organization = await _organizationRepository.GetByIdAsync(id);
            return PartialView("~/Views/Organization/Delete.cshtml", organization);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _organizationRepository.DeleteAsync(id);
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

    
