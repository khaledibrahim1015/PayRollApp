using PayCompute.Entity;
using System.ComponentModel.DataAnnotations;
using System;

namespace PayCompute.Models
{
    public class EmployeeDetailsViewModel
    {
        public int Id { get; set; }
  
        public string EmployeeNo { get; set; }
        public string FullName { get; set; }

        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateJoined { get; set; }

        public string PhoneNumber { set; get; }
        public string Designation { get; set; }
        public string Email { get; set; }
      
        public string NationalInsuranceNo { get; set; }


        public PaymentMethod PaymentMethod { get; set; }
        public StudentLoan StudentLoan { get; set; }
        public UnionMember UnionMember { set; get; }



        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }


    }
}
