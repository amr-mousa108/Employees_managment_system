using Demo.BLL.Interfaces;
using Demo.BLL.Repositories;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
namespace Amr_Mousa_Elewa.PL.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeeRepository)

        {
           _employeeRepository= employeeeRepository;
        }
        //  /Employee/Index/
        public IActionResult Index()
        {
            var Employees = _employeeRepository.GetAll();
            return View(Employees);
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
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var count = _employeeRepository.Add(employee);
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }


        [HttpGet]
        public IActionResult Details(int? id)
        {
            var employee = _employeeRepository.Get(id.Value);

            return View(employee);

        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
   

    // POST: Employee/UpdateData/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateData(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", employee); // Return to the edit view if the model state is invalid
            }

            var existingEmp = _employeeRepository.Get(id);
            if (existingEmp == null)
            {
                return NotFound();
            }

            // Update the existing employee
            existingEmp.Name = employee.Name;
            existingEmp.Age = employee.Age;
            existingEmp.IsActive = employee.IsActive;
            existingEmp.Address = employee.Address;
            existingEmp.PhoneNumber = employee.PhoneNumber;
            existingEmp.Email = employee.Email;
            existingEmp.Salary = employee.Salary;
            existingEmp.HireDate = employee.HireDate;
            existingEmp.CreationDate = employee.CreationDate; 
            existingEmp.Image = employee.Image;

            _employeeRepository.Update(existingEmp);
            TempData["Message"] = $"The Employee {existingEmp.Name} was edited successfully!";

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            // Fetch the department from the database
            var emp = _employeeRepository.Get(id);

            // Check if the department exists
            if (emp == null)
            {
                return NotFound();
            }

            // Call the Delete method with the department object
            _employeeRepository.Delete(emp);
            TempData["Message"] = $"The Employee {emp.Name} was deleted successfully!";

            // Redirect to the Index action after deletion
            return RedirectToAction("Index");
        }



    }
}
    


