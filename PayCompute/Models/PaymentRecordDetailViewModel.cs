using PayCompute.Entity;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace PayCompute.Models
{
    public class PaymentRecordDetailViewModel
    {
        public int Id { set; get; }

       
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public string NINO { get; set; }// NationalInsuranceNo

        [DataType(DataType.Date), Display(Name = "Pay Date")]
        public DateTime PayDate { get; set; } 

        [Display(Name = "Pay Month")]
        public string PayMonth { get; set; } 



        // RealtionShip
        [Display(Name = "Tax Year")]
        public int TaxYearId { get; set; }
        public string Year { get; set; }
        public TaxYear TaxYear { set; get; }


        [Display(Name = "Tax Code")]
        public string TaxCode { get; set; }
        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate { get; set; }
        [Display(Name = "Hourly Worked")]
        public decimal HourlyWorked { get; set; }
        [Display(Name = "Contractual Hours")]
        public decimal ContractualHours { get; set; } = 160m;
        [Display(Name = "OverTime Hours")]
        public decimal OverTimeHours { get; set; }

        [Display(Name = "OverTime Rate")]
        public decimal OverTimeRate { get; set; }
        [Display(Name = "Contractual Earnings")]
        public decimal ContractualEarnings { get; set; }
        [Display(Name = "OverTime Earnings ")]
        public decimal OverTimeEarnings { get; set; }

        public decimal Tax { get; set; }

        public decimal NIC { get; set; }// NATIONAL INSURANCE CONTRIBUATION
        [Display(Name = "Union Fee")]
        public decimal? UnionFee { get; set; } // hOur Deductions       //  Nullable => Optional


        public Nullable<decimal> SLC { get; set; } // student loan company    //  Nullable => Optional

        [Display(Name = "Total Earnings")]
        public decimal TotalEarnings { get; set; }
        [Display(Name = "Total Deduction")]
        public decimal TotalDeduction { get; set; }

        [Display(Name = "Net Payment")]
        public decimal NetPayment { get; set; }

    }
}
