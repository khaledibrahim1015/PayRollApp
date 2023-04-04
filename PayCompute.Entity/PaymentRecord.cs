using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayCompute.Entity
{
    public  class PaymentRecord
    {
        public int Id { set; get; }




        //  Relationship 
        // One PaymenTRecord Assign to one Employee 
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        // Emp Properties
        [MaxLength(100)]
        public string FullName { get; set; }

        public string NINO { get; set; }// NationalInsuranceNo

        public DateTime PayDate { get; set; } // PaymentDateTime
        public string PayMonth { get; set; }



        // RealtionShip
        [ForeignKey("TaxYear")]
        public int TaxYearId { get; set; }
        public TaxYear TaxYear { set; get; }



        public string TaxCode { get; set; }
        [Column(TypeName = "money")]
        public decimal HourlyRate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal HourlyWorked { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ContractualHours { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal OverTimeHours { get; set; }
        [Column(TypeName = "money")]
        public decimal ContractualEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal OverTimeEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal Tax { get; set; }
        [Column(TypeName = "money")]
        public decimal NIC { get; set; }// NATIONAL INSURANCE CONTRIBUATION
        [Column(TypeName = "money")]
        public decimal? UnionFee { get; set; } // hOur Deductions       //  Nullable => Optional

        [Column(TypeName = "money")]
        public Nullable<decimal> SLC { get; set; } // student loan company    //  Nullable => Optional

        [Column(TypeName = "money")]
        public decimal TotalEarnings { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalDeduction { get; set; }

        [Column(TypeName ="money")]
        public decimal NetPayment { get; set; }



















    }
}
