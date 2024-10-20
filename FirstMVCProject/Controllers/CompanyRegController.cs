using FirstMVCProject.Dto.Company;
using FirstMVCProject.Services.CompanyRegService;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCProject.Controllers
{
	[Route("Company-Registration")]
	public class CompanyRegController : Controller
	{
		private readonly ICompanyService _companyService;

		public CompanyRegController(ICompanyService companyService)
		{
			_companyService = companyService;
		}

		[HttpGet("all-companies")]
		public async Task<IActionResult> Company()
		{
			var result = await _companyService.GetAllCompany();
			return View(result.Data);
		} 

		[HttpGet("company/{id}")]
		public async Task<IActionResult> CompanyDetailsAsync([FromRoute]Guid id)
		{
			var result = await _companyService.GetCompany(id);
			return View(result.Data);
		}

		[HttpGet("create-company")]
		public async Task<IActionResult> CreateCompany()
		{
			return View();
		} 

		[HttpPost("create-company")]
		public async Task<IActionResult> CreateCompany([FromForm] CreateCompanyDto request)
		{
			var result = await _companyService.CreateCompany(request);
			if (result.IsSuccessful)
			{
				return RedirectToAction("Company");
			}
			return RedirectToAction("CreateCompany");
		}

		[HttpGet("update-company-record/{id}")]
		public async Task<IActionResult> UpdateCompany([FromRoute]Guid id)
		{
			var result = await _companyService.GetCompany(id);
			return View(result.Data);
		}

		[HttpPost("update-company-record/{id}")]
		public async Task<IActionResult> UpdateCompany([FromRoute]Guid id, [FromForm]UpdateCompany request)
		{
		    var result = await _companyService.UpdateCompany(id, request);
			if (result.IsSuccessful)
			{
				return RedirectToAction("Company", new { id = id });
			}
			return RedirectToAction("CompanyDetails");
		}

		[HttpGet("delete-company/{id}")]
		public async Task<IActionResult> DeleteCompany([FromRoute] Guid id)
		{
			var result = await _companyService.Delete(id);
			if (result.IsSuccessful)
			{
				return RedirectToAction("Company");
			}
			return RedirectToAction("Company");
		}
	}
}