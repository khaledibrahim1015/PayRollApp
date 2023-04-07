using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using PayCompute.Entity;
using PayCompute.Models;
using PayCompute.Services;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace PayCompute.Controllers
{
    [Authorize]
    public class EmployeeController :Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeeController(IEmployeeService employeeService,IWebHostEnvironment webHostEnvironment)
        {
            _employeeService = employeeService;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {

            var employeeList = _employeeService.GetAll().Select(employee => new EmployeeIndexViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                DateJoined = employee.DateJoined,
                Designation = employee.Designation,
                City = employee.City,
                ImageUrl=employee.ImageUrl
            }).ToList();

            return View(employeeList);


        }

        [HttpGet]
        public IActionResult Create()
        {
            EmployeeCreateViewModel employeeCreateViewModel = new EmployeeCreateViewModel();
            return View(employeeCreateViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] //  Prevent Cross-Site Request Forgery Attacks 
        public async Task<IActionResult> Create (EmployeeCreateViewModel employeeCreateViewModel)
        {
            
            if(ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    //Mapping 
                    Id = employeeCreateViewModel.Id,
                    EmployeeNo = employeeCreateViewModel.EmployeeNo,
                    FirstName = employeeCreateViewModel.FirstName,
                    MiddleName = employeeCreateViewModel.MiddleName,
                    LastName = employeeCreateViewModel.LastName,
                    FullName = employeeCreateViewModel.FullName,
                    Gender = employeeCreateViewModel.Gender,
                    Email = employeeCreateViewModel.Email,
                    DOB = employeeCreateViewModel.DOB,
                    DateJoined = employeeCreateViewModel.DateJoined,
                    NationalInsuranceNo = employeeCreateViewModel.NationalInsuranceNo,
                    PaymentMethod = employeeCreateViewModel.PaymentMethod,
                    UnionMember = employeeCreateViewModel.UnionMember,
                    StudentLoan = employeeCreateViewModel.StudentLoan,
                    Address = employeeCreateViewModel.Address,
                    City = employeeCreateViewModel.City,
                    PhoneNumber = employeeCreateViewModel.PhoneNumber,
                    PostCode = employeeCreateViewModel.PostCode,
                    Designation = employeeCreateViewModel.Designation


                };
                //  For Image Upload

                //var files = HttpContext.Request.Form.Files;

                // mean image is uploaded
                if(employeeCreateViewModel.ImageUrl!=null && employeeCreateViewModel.ImageUrl.Length>0)
                {


                    var webRootPath = _webHostEnvironment.WebRootPath;
                    var uploadDirectory = @"images/employee";
                    //var uploadDirectory = WebConstant.uploadDirectory;

                    var fileName = Path.GetFileNameWithoutExtension(employeeCreateViewModel.ImageUrl.FileName);

                    var Extension = Path.GetExtension(employeeCreateViewModel.ImageUrl.FileName);

                    
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + Extension; //  like Migration filename 

                    var path = Path.Combine(webRootPath, uploadDirectory, fileName);


                    //using( var filestrem=new FileStream(path,FileMode.Create))
                    //{
                    //    employeeCreateViewModel.ImageUrl.CopyToAsync(filestrem);
                    //}

                   await employeeCreateViewModel.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));



                    // Finaly create imageUrl In db 

                    employee.ImageUrl = "/" + uploadDirectory + "/" + fileName;

                }



                //  Create Employee in db 

                  await _employeeService.CreateAsync(employee);
                return RedirectToAction(nameof(Index));


            }
            return View(employeeCreateViewModel);

        }




        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var  employee = _employeeService.GetById(id);

            if (employee == null)
                return NotFound();

            var model = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                DateJoined = employee.DateJoined,
                NationalInsuranceNo = employee.NationalInsuranceNo,
                PaymentMethod = employee.PaymentMethod,
                UnionMember = employee.UnionMember,
                StudentLoan = employee.StudentLoan,
                Address = employee.Address,
                City = employee.City,
                PhoneNumber = employee.PhoneNumber,
                PostCode = employee.PostCode,
                Designation = employee.Designation




            };



            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(EmployeeEditViewModel employeeEditViewModel)
        {
            if(ModelState.IsValid)
            {
                var employee = _employeeService.GetById(employeeEditViewModel.Id);

                if (employee == null)
                {
                    return NotFound();

                }
                    
                else
                {
                    employee.Id = employeeEditViewModel.Id;
                    employee.EmployeeNo = employeeEditViewModel.EmployeeNo;
                    employee.FirstName = employeeEditViewModel.FirstName;
                    employee.MiddleName = employeeEditViewModel.MiddleName;
                    employee.LastName = employeeEditViewModel.LastName;
                    employee.Gender = employeeEditViewModel.Gender;
                    employee.Email = employeeEditViewModel.Email;
                    employee.DOB = employeeEditViewModel.DOB;
                    employee.DateJoined = employeeEditViewModel.DateJoined;
                    employee.NationalInsuranceNo = employeeEditViewModel.NationalInsuranceNo;
                    employee.PaymentMethod = employeeEditViewModel.PaymentMethod;
                    employee.UnionMember = employeeEditViewModel.UnionMember;
                    employee.StudentLoan = employeeEditViewModel.StudentLoan;
                    employee.Address = employeeEditViewModel.Address;
                    employee.City = employeeEditViewModel.City;
                    employee.PhoneNumber = employeeEditViewModel.PhoneNumber;
                    employee.PostCode = employeeEditViewModel.PostCode;
                    employee.Designation = employeeEditViewModel.Designation;

                    // Image 

                    if (employeeEditViewModel.ImageUrl != null && employeeEditViewModel.ImageUrl.Length > 0)
                    {
                        var webRootPath = _webHostEnvironment.WebRootPath;

                        var uploadDirectory = WebConstant.uploadDirectory;

                        var fileName = Path.GetFileNameWithoutExtension(employeeEditViewModel.ImageUrl.FileName);

                        var Extension = Path.GetExtension(employeeEditViewModel.ImageUrl.FileName);

                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + Extension;

                        var path = Path.Combine(webRootPath, uploadDirectory, fileName);

                        // Before create on server => Delete old file 
                        var oldFile = webRootPath + employee.ImageUrl;

                        if (System.IO.File.Exists(oldFile))
                        {

                            System.IO.File.Delete(oldFile);
                        }

                      await  employeeEditViewModel.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));

                        // update 
                        employee.ImageUrl = "/" + uploadDirectory + "/" + fileName;


                    }


                  await  _employeeService.UpdateAsync(employee);
                    return RedirectToAction(nameof(Index));


                }
            }
            return View(employeeEditViewModel);
        }



        [HttpGet]
        public IActionResult Details(int? id )
        {
            if (id == null || id == 0)
                return NotFound();

            var employee = _employeeService.GetById(id);

            if (employee == null)
                return NotFound();

            EmployeeDetailsViewModel model = new EmployeeDetailsViewModel()
            {
                Id=employee.Id,
                EmployeeNo=employee.EmployeeNo,
                FullName=employee.FullName,
                Gender=employee.Gender,
                DOB=employee.DOB,
                DateJoined=employee.DateJoined,
                PhoneNumber=employee.PhoneNumber,
                Designation=employee.Designation,
                Email=employee.Email,
                NationalInsuranceNo=employee.NationalInsuranceNo,
                Address=employee.Address,
                City=employee.City,
                PostCode=employee.PostCode,
                PaymentMethod=employee.PaymentMethod,
                StudentLoan=employee.StudentLoan,
                UnionMember=employee.UnionMember,
                ImageUrl=employee.ImageUrl

            };

            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int? id )
        {
            if (id == null || id == 0)
                return NotFound();

            Employee employee = _employeeService.GetById(id);

            if (employee == null)
                return NotFound();

            EmployeeDeleteViewModel model = new()
            {
                Id=employee.Id,
                FullName=employee.FullName
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(EmployeeDeleteViewModel model)
        {
            var employee = _employeeService.GetById(model.Id);

            if (employee == null)
                return NotFound();


            string webRootPath = _webHostEnvironment.WebRootPath;
            var path = webRootPath + employee.ImageUrl;

            if(System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            
            await   _employeeService.DeleteAsync(employee.Id);
            return RedirectToAction(nameof(Index));


        }








    }
}
