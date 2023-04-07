using Microsoft.AspNetCore.Mvc.Rendering;
using PayCompute.Entity;
using PayCompute.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCompute.Services.Implementation
{
    public class PayComputationService : IPayComputationService
    {
        private decimal contractualEarnings;
        private decimal overTimeHours;

        private readonly ApplicationDbContext _context;

        public PayComputationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreatAsync(PaymentRecord paymentRecord)
        {
           await _context.PaymentRecords.AddAsync(paymentRecord);
           await _context.SaveChangesAsync();
        }

        public IEnumerable<PaymentRecord> GetAll() => _context.PaymentRecords.OrderBy(p => p.EmployeeId);
       

        public IEnumerable<SelectListItem> GetAllTaxYear()
        {
            var allTaxYear = _context.TaxYears.Select(taxyear => new SelectListItem
            {
                Text = taxyear.YearOfTax,
                Value = taxyear.Id.ToString()
            });
            return allTaxYear;
        }

        public PaymentRecord GetById(int? id) => _context.PaymentRecords.Where(p => p.Id == id).SingleOrDefault();
       



        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            if (hoursWorked < contractualHours)
            {
                contractualEarnings = hoursWorked * hourlyRate;

            }
            else
            {
                contractualEarnings = contractualHours * hourlyRate;
            }


            return contractualEarnings;


          //  return hoursWorked<contractualHours ? contractualEarnings = hoursWorked * hourlyRate : contractualEarnings = contractualHours * hourlyRate;
        }



        public decimal OverTimeHours(decimal hoursWorked, decimal contractualHours)
        {
          if(hoursWorked <= contractualHours)
            {
                overTimeHours = 0.00m;
            }
            else if(hoursWorked > contractualHours)
            {
                overTimeHours = hoursWorked - contractualHours;
            }
            return overTimeHours;
        }

        public decimal OverTimeRate(decimal hourlyRate)
        => hourlyRate * 1.5m;

        public decimal OverTimeEarnings(decimal overTimeRate, decimal overTimeHours)
        => overTimeRate * overTimeHours;



        public decimal TotalDeduction(decimal tax, decimal nic)
        => tax + nic ;


        public decimal TotalEarnings(decimal overTimeEarnings, decimal contractualEarnings)
        => overTimeEarnings + contractualEarnings;


        public decimal NetPay(decimal totalEarnings, decimal totalDeduction)
        => totalEarnings - totalDeduction;

        public TaxYear GetTaxYearById(int id)
       => _context.TaxYears.Where(year => year.Id == id).SingleOrDefault();
    }
}
