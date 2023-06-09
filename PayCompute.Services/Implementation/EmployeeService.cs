﻿using Microsoft.AspNetCore.Mvc.Rendering;
using PayCompute.Entity;
using PayCompute.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCompute.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private decimal studentLoanAmount;
        

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task CreateAsync(Employee newEmployee)
        {

          await  _context.Employees.AddAsync(newEmployee);
           await _context.SaveChangesAsync();

        }



        public Employee GetById(int? employeeId)
        => _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();


        public async Task DeleteAsync(int employeeId)
        {
            var employee = GetById(employeeId);
             _context.Employees.Remove(employee);
           await _context.SaveChangesAsync();
        }



        public IEnumerable<Employee> GetAll()
            => _context.Employees;
      

      


        public async Task UpdateAsync(Employee employee)
        {
                  _context.Employees.Update(employee);
          await  _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            _context.Update(employee);
          await  _context.SaveChangesAsync();
        }



        public IEnumerable<SelectListItem> GetAllEmployeesForPayRoll()
        {
           return  _context.Employees.Select(emp => new SelectListItem()
            {
                Text = emp.FullName,
                Value = emp.Id.ToString()
            }) ;
        }
    }
}
