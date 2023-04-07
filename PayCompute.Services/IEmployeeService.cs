using Microsoft.AspNetCore.Mvc.Rendering;
using PayCompute.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCompute.Services
{
    public  interface IEmployeeService
    {

        Task CreateAsync(Employee newEmployee);

        Task UpdateAsync(Employee employee);

        Task UpdateAsync(int id);


        Task DeleteAsync(int employeeId);

        Employee GetById(int? employeeId);

        IEnumerable<Employee> GetAll();

        IEnumerable<SelectListItem> GetAllEmployeesForPayRoll();


    }
}
