using FirstMVCProject.Dto.Company;
using FirstMVCProject.Dto.Employees;
using FirstMVCProject.Services.EmployeeServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCProject.Controllers
{
	public class EmployeeController : Controller	
	{
		private readonly IEmployeeService _employeeService;

		public EmployeeController(IEmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpGet("all-employees/{companyId}")]
		public async Task<IActionResult> Employee(Guid companyId)
		{
			var result = await _employeeService.GetAllEmployeesByCompanyId(companyId);
            return View(result.Data);
		}

		[HttpGet("employee-details/{id}")]
		public async Task<IActionResult> EmployeeDetailsAsync([FromRoute] Guid id)
		{
			var result = await _employeeService.GetEmployee(id);
			return View(result.Data);
		}


		[HttpGet("create-employee/{companyId}")]
		public async Task<IActionResult> AddEmployee(Guid companyId)
		{
			return View();
		}

        [HttpPost("create-employee/{companyId}")]
        public async Task<IActionResult> AddEmployee(Guid companyId, [FromForm] AddEmployeeDto request)
        {
            request.CompanyId = companyId;
            var result = await _employeeService.AddEmployee(request);

            if (result.IsSuccessful)
            {
                return RedirectToAction("Employee", new { companyId = companyId });
            }

            return View(request);
        }



		[HttpGet("update-employee-record/{id}")]
		public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id)
		{
			var result = await _employeeService.GetEmployee(id);
			return View(result.Data);
		}

		[HttpPost("update-employee-record/{id}")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, [FromForm] UpdateEmployeeDto request)
		{
			var result = await _employeeService.UpdateEmployee(id, request);
			if (result.IsSuccessful)
			{
				return RedirectToAction("Employee", new { id = id });
			}
			return RedirectToAction("EmployeeDetails");
		}

		[HttpGet("delete-employee/{id}")]
		public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
		{
			var result = await _employeeService.Delete(id);
			if (result.IsSuccessful)
			{
				return RedirectToAction("Employee");
			}
			return RedirectToAction("Employee");
		}
	}
}
