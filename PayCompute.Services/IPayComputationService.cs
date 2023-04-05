using Microsoft.AspNetCore.Mvc.Rendering;
using PayCompute.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCompute.Services
{
    public interface IPayComputationService
    {
        Task CreatAsync(PaymentRecord paymentRecord);

        PaymentRecord GetById(int id);

        IEnumerable<PaymentRecord> GetAll();

        IEnumerable<SelectListItem> GetAllTaxYear();

        decimal OverTimeHours(decimal hoursWorked, decimal contractualHours);

        decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate);

        decimal OverTimeRate(decimal hourlyRate);

        decimal OverTimeEarnings(decimal overTimeRate, decimal overTimeHours);

        decimal TotalEarnings(decimal overTimeEarnings,decimal contractualEarnings);

        decimal TotalDeduction(decimal tax, decimal nic, decimal studentLoanRepayment, decimal unionFee);

        decimal NetPay(decimal totalEarnings, decimal totalDeduction);





    }
}
