using Microsoft.AspNetCore.Mvc;
using PayCompute.Entity;
using PayCompute.Models;
using PayCompute.Services;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PayCompute.Controllers
{
    public class PayController : Controller
    {
        private decimal overTimeHours;
        private decimal contractualEarnings;
        private decimal overtimeEarnings;
        private decimal totalAmount;
        private decimal tax;
        private decimal nationalInsuranceContribution;
        private decimal unionFee;
        private decimal totalDeductions;
        private decimal studentLoan;
        
        private readonly IPayComputationService _payComputationService;

        private readonly INatiomalInsuranceContributionService _natiomalInsuranceContributionService;
        private readonly ITaxService _taxService;
        private readonly IEmployeeService _employeeService;

        public PayController(IPayComputationService payComputationService, INatiomalInsuranceContributionService natiomalInsuranceContributionService, ITaxService taxService, IEmployeeService employeeService)
        {
            _payComputationService = payComputationService;
            _natiomalInsuranceContributionService = natiomalInsuranceContributionService;
            _taxService = taxService;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var PayRecords = _payComputationService.GetAll().Select(paymentRecord => new PaymentRecordIndexViewModel
            {
                Id = paymentRecord.Id,
                EmployeeId=paymentRecord.EmployeeId,
                FullName=paymentRecord.FullName,
                PayDate=paymentRecord.PayDate,
                PayMonth=paymentRecord.PayMonth,
                TaxYearId=paymentRecord.TaxYearId,
                //Year=paymentRecord.TaxYear.YearOfTax,//
                Year=_payComputationService.GetTaxYearById(paymentRecord.TaxYearId).YearOfTax,
                TotalEarnings=paymentRecord.TotalEarnings,
                TotalDeduction=paymentRecord.TotalDeduction,
                NetPayment=paymentRecord.NetPayment

            });


            return View(PayRecords);
        }

        [HttpGet]
        public IActionResult Create ()
        {
            ViewBag.EmployeeList = _employeeService.GetAllEmployeesForPayRoll(); // DropDownList => map EmployeeId
            ViewBag.TaxYears = _payComputationService.GetAllTaxYear(); // DropDownList  => map  TaxYearId
            var model = new PaymentRecordCreateViewModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentRecordCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var paymentRecord = new PaymentRecord()
                {
                    Id = model.Id,
                    EmployeeId = model.EmployeeId,
                    FullName = _employeeService.GetById(model.EmployeeId).FullName, // 
                    NINO = _employeeService.GetById(model.EmployeeId).NationalInsuranceNo,
                    PayDate = model.PayDate,
                    PayMonth = model.PayMonth,
                    TaxYearId = model.TaxYearId,
                    TaxCode = model.TaxCode,
                    HourlyRate = model.HourlyRate,
                    HourlyWorked = model.HourlyWorked,
                    ContractualHours = model.ContractualHours,
                    OverTimeHours =overTimeHours= _payComputationService.OverTimeHours(model.HourlyWorked, model.ContractualHours),// this called multiple assignment expression
                    ContractualEarnings = contractualEarnings = _payComputationService.ContractualEarnings(model.ContractualHours, model.HourlyWorked, model.HourlyRate),//multiple assignment expression
                    OverTimeEarnings = overtimeEarnings= _payComputationService.OverTimeEarnings(_payComputationService.OverTimeRate(model.HourlyRate), overTimeHours),////////multiple assignment expression

                    TotalEarnings = totalAmount=_payComputationService.TotalEarnings(overtimeEarnings, contractualEarnings),///////multiple assignment expression

                    Tax = tax= _taxService.TaxAmount(totalAmount),//multiple assignment expression

                    UnionFee = unionFee=_employeeService.UnionFees(model.EmployeeId),

                    SLC = studentLoan=_employeeService.StudentLoanRePaymentAmount(model.Id,totalAmount),

                    NIC =nationalInsuranceContribution= _natiomalInsuranceContributionService.NIContribution(totalAmount),//multiple assignment expression


                    TotalDeduction = totalDeductions=_payComputationService.TotalDeduction(tax, nationalInsuranceContribution, studentLoan, unionFee),

                    NetPayment = _payComputationService.NetPay(totalAmount, totalDeductions),
                    
                   
                   
                    

                };

              await  _payComputationService.CreatAsync(paymentRecord);
                return RedirectToAction(nameof(Index));

            }


            ViewBag.EmployeeList = _employeeService.GetAllEmployeesForPayRoll(); // DropDownList => map EmployeeId
            ViewBag.TaxYears = _payComputationService.GetAllTaxYear(); // DropDownList  => map  TaxYearId
            return View(model);

            
        }





    }
}
