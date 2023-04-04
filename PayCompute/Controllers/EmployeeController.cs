using Microsoft.AspNetCore.Mvc;
using PayCompute.Models;
using PayCompute.Services;
using System.Linq;

namespace PayCompute.Controllers
{
    public class EmployeeController :Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        public IActionResult Index()
        {

            var employeeList = _employeeService.GetAll().Select(employee => new EmployeeIndexViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                DateJoined = employee.DateJoined,
                Designation = employee.Designation,
                City = employee.City
            }).ToList();

            return View();


        }



    }
}
