using PayCompute.Entity;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel;
using Microsoft.AspNetCore.Http;

namespace PayCompute.Models
{
    public class EmployeeCreateViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Employee Number is Required"),
         RegularExpression(@"^[A-Z]{3,3}[0-9]{3}$")]
        public string EmployeeNo { get; set; }



        [Required(ErrorMessage ="First Name is required") ,StringLength(50,MinimumLength =3)]
        [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$")]
        [Display(Name ="Fisrt Name ")]
        public string FirstName { get; set; }


        
        [StringLength(50),Display(Name = "Middle Name")]
        public string MiddleName { get; set; }// OPtional then may not set 


        [Required(ErrorMessage = "Last Name is required"), StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z][a-zA-Z""'\s-]*$")]
        [Display(Name = "Last Name ")]
        public string LastName { get; set; }


        //  Full Name without set get return firstName+MiddleName[0].+LastName
        public string FullName { get { return FirstName + (string.IsNullOrEmpty(MiddleName) ? " " : (" " + (char?)MiddleName[0] + ".").ToUpper() ) + LastName; } }

        public string Gender { get; set; }

        [Display(Name ="Photo")]
        public IFormFile ImageUrl { get; set; }  //  Note imageurl saved in db as string 


        [DataType(DataType.Date),Display(Name ="Date Of Birth ")]
        public DateTime DOB { get; set; }


        [DataType(DataType.Date), Display(Name = "Date Joined ")]
        public DateTime DateJoined { get; set; } = DateTime.UtcNow;


        [Display(Name ="Phone ")]
        public string PhoneNumber { set; get; }


        [Display(Name ="Role"),Required(ErrorMessage ="Job Role Is Required"),StringLength(100)]
        public string Designation { get; set; } // Employee JobRole


        [DataType(DataType.EmailAddress),]
        public string Email { get; set; }


        [Required (ErrorMessage ="National Insurance Number is Required"), StringLength(50),Display(Name ="National Insurance NO.")]
        public string NationalInsuranceNo { get; set; } //  will put a regular expression for validate => must 296+birtofdate


        [Display(Name ="Payment Method")]
        public PaymentMethod PaymentMethod { get; set; }




        [Required, StringLength(150)]
        public string Address { get; set; }
        [Required, StringLength(50)]
        public string City { get; set; }
        [Required, StringLength(50)]
        public string PostCode { get; set; }


    }
}
