using FirstMVCProject.Dto.HealthStatus;
using FirstMVCProject.Services.EmployeeServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCProject.Controllers
{
    public class HealthStatusController : Controller
	{
		private readonly IHealthStatus _healthStatusService;

		public HealthStatusController(IHealthStatus healthStatusService)
		{
			_healthStatusService = healthStatusService;
		}

		[HttpGet("all-status")]
		public async Task<IActionResult> HealthStatus()
		{
			var result = await _healthStatusService.GetAllHealthStatusInfo();
			return View(result.Data);
		}

		[HttpGet("health-status/{id}")]
		public async Task<IActionResult> HealthDetailsAsync([FromRoute] Guid id)
		{
			var result = await _healthStatusService.GetHealthStatusInfo(id);
			return View(result.Data);
		}

		[HttpGet("create-HealthInfo")]
		public async Task<IActionResult> AddHealthInfo()
		{
			return View();
		}

		[HttpPost("create-HealthInfo")]
		public async Task<IActionResult> AddHealthInfoAsync([FromForm] HealthStatusDto request)
		{
			var result = await _healthStatusService.AddHealthStatusInfo(request);
			if (result.IsSuccessful)
			{
				Url.Action("Employee", "Employee");
			}
			return RedirectToAction("AddHealthInfo");
		}


		[HttpGet("update-health-status/{id}")]
		public async Task<IActionResult> UpdateHealthStatus([FromRoute] Guid id)
		{
			var result = await _healthStatusService.GetHealthStatusInfo(id);
			return View(result.Data);
		}

		[HttpPost("update-nextofkin-record/{id}")]
		public async Task<IActionResult> UpdateHealthStatus([FromRoute] Guid id, [FromForm] UpdateHealthStatusDto request)
		{
			var result = await _healthStatusService.UpdateStatus(id, request);
			if (result.IsSuccessful)
			{
				Url.Action("Employee","Employee", new { id = id });
			}
			return RedirectToAction("EmployeeDetails");
		}

		//[HttpGet("delete-employee/{id}")]
		//public async Task<IActionResult> DeleteHealthStatus([FromRoute] Guid id)
		//{
		//	var result = await _healthStatusService.Delete(id);
		//	if (result.IsSuccessful)
		//	{
		//		Url.Action("Employee","Employee");
		//	}
		//	return RedirectToAction("Employee");
		//}
	}
}
