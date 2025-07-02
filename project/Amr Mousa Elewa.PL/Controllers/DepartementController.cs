using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Amr_Mousa_Elewa.PL.Controllers
{
    //Composition :departementcontroller has a dapartementrepository
    //inheritance :departementcontroller is a controller
    public class DepartementController : Controller
    {
        private readonly IDepartementRepository _departementRepo;
        public DepartementController(IDepartementRepository departementRepository)

        {
            _departementRepo = departementRepository;
        }
        //  /Departement/Index/
        public IActionResult Index()
        {
            var departements = _departementRepo.GetAll();
            return View(departements);
        }
        public IActionResult Details()
        {
            return View();

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Departement departement)
        {
            if (ModelState.IsValid)
            {
                var count = _departementRepo.Add(departement);
                if (count > 0) 
                    TempData["Message"] = $"The Departement {departement.Name} was created successfully!";

                return RedirectToAction(nameof(Index));
            }

            return View(departement);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            var depart = _departementRepo.Get(id.Value);

            return View(depart);

        }
        public IActionResult Edit(int id)
        {
            var dept = _departementRepo.Get(id);
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }

        // POST: Departement/UpdateData
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateData(int id, Departement departement)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", departement); // Return to the edit view if the model state is invalid
            }

            var existingDept = _departementRepo.Get(id);
            if (existingDept == null)
            {
                return NotFound();
            }

            // Update the existing department
            existingDept.Code = departement.Code;
            existingDept.Name = departement.Name;
            existingDept.DateOfCreation = departement.DateOfCreation;

            _departementRepo.Update(existingDept);
            TempData["Message"] = $"The Departement {existingDept.Name} was edited successfully!";

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            // Fetch the department from the database
            var dept = _departementRepo.Get(id);

            // Check if the department exists
            if (dept == null)
            {
                return NotFound();
            }

            // Call the Delete method with the department object
            _departementRepo.Delete(dept);
            TempData["Message"] = $"The departement {dept.Name} was deleted successfully!";

            // Redirect to the Index action after deletion
            TempData["Message"] = $"The Departement {dept.Name} was deleted successfully!";
            return RedirectToAction("Index");
        }



    }
}