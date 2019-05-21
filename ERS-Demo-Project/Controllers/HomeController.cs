using ERS_Demo_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERS_Demo_Project.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            var Employee = new Employee()
            {
                Name = employee.Name,
                Code = employee.Code,
                Phone = employee.Phone,
                JobPosition = employee.JobPosition
            };

            _context.Employees.Add(Employee);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult ReadEmployee()
        {
            var Employees = _context.Employees.ToList();
            return View(Employees);
        }

        [HttpGet]
        public ActionResult UpdateEmployee(int ID)
        {
            var SelectedEmployee = _context.Employees.Find(ID);
            return View(SelectedEmployee);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee)
        {
            var SelectedEmployee = _context.Employees.Find(employee.ID);
            SelectedEmployee.Name = employee.Name;
            SelectedEmployee.Code = employee.Code;
            SelectedEmployee.Phone = employee.Phone;
            SelectedEmployee.JobPosition = employee.JobPosition;
            _context.SaveChanges();
            return RedirectToAction("ReadEmployee", "Home");
        }

        [HttpGet]
        public ActionResult DeleteEmployee(int ID)
        {
            var SelectedEmployee = _context.Employees.Find(ID);
            return View(SelectedEmployee);
        }

        [HttpPost]
        public ActionResult DeleteEmployee(Employee employee)
        {
            var SelectedEmployee = _context.Employees.Find(employee.ID);
            _context.Employees.Remove(SelectedEmployee);
            _context.SaveChanges();
            return RedirectToAction("ReadEmployee", "Home");
        }

    }
}