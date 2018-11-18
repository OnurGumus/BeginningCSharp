using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCEF.Models;
using MVCEF.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCEF.Controllers
{
    public class EmployeeController : Controller
    {
        readonly EmployeeDbContext employeeDbContext;
        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            this.employeeDbContext = employeeDbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var employeeAddViewModel = new EmployeeAddViewModel();
            var db = this.employeeDbContext;
            employeeAddViewModel.EmployeesList = db.Employees.ToList();
            employeeAddViewModel.NewEmployee = new Employee();
            if (Request.Headers["accept"].Any(x=> x=="application/json"))
            {
                return Ok(employeeAddViewModel);
            }

            return View(employeeAddViewModel);
        }

        [HttpPost]
        public IActionResult Index(EmployeeAddViewModel employeeAddViewModel)
        {

            var db = this.employeeDbContext;
            db.Employees.Add(employeeAddViewModel.NewEmployee);
            db.SaveChanges();
            //Redirect to get Index GET method
            return RedirectToAction("Index");

        }


    }
}
