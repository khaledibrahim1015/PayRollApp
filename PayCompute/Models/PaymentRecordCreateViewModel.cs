using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PayCompute.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace PayCompute.Models
{
    public class PaymentRecordCreateViewModel
    {


        public int Id { set; get; }

        [Display(Name ="Full Name")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string FullName { get; set; }

        public string NINO { get; set; }// NationalInsuranceNo

        [DataType(DataType.Date), Display(Name = "Pay Date")]
        public DateTime PayDate { get; set; } = DateTime.UtcNow;// PaymentDateTime

        [Display(Name = "Pay Month")]
        public string PayMonth { get; set; } = DateTime.Today.Month.ToString();



        // RealtionShip
        [Display(Name ="Tax Year")]
        public int TaxYearId { get; set; }
        public TaxYear TaxYear { set; get; }



        public string TaxCode { get; set; }
        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate { get; set; }
        [Display(Name = "Hours Worked")]
        public decimal HourlyWorked { get; set; }
        [Display(Name = "Contractual Hours")]
        public decimal ContractualHours { get; set; } = 160m;

        public decimal OverTimeHours { get; set; }
     
        public decimal ContractualEarnings { get; set; }
   
        public decimal OverTimeEarnings { get; set; }
      
        public decimal Tax { get; set; }
    
        public decimal NIC { get; set; }// NATIONAL INSURANCE CONTRIBUATION
       
      
      
        public decimal TotalEarnings { get; set; }
      
        public decimal TotalDeduction { get; set; }

        
        public decimal NetPayment { get; set; }




    }
}
