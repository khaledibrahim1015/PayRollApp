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



        decimal UnionFees(int id); //  check for if employee if an unionmember  then if employee a unionMember will check to apply union fees

        decimal StudentLoanRePaymentAmount(int id, decimal totalAmount);


        IEnumerable<SelectListItem> GetAllEmployeesForPayRoll();


    }
}
