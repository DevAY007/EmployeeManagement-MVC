using FirstMVCProject.Dto.NextOfKin;
using FirstMVCProject.Services.EmployeeServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCProject.Controllers
{
	public class NextOfKinController : Controller
	{
		private readonly INextOfKinService _nextOfKinService;

		public NextOfKinController(INextOfKinService nextOfKinService)
		{
			_nextOfKinService = nextOfKinService;
		}

		[HttpGet("all-record")]
		public async Task<IActionResult> NextOfKinRecord()
		{
			var result = await _nextOfKinService.GetAllNextOfKinRecord();
			return View(result.Data);
		}

		[HttpGet("nextofkin-record/{id}")]
		public async Task<IActionResult> NextOfKinDetails([FromRoute] Guid id)
		{
			var result = await _nextOfKinService.GetNextOfKinInfo(id);
			return View(result.Data);
		}

		[HttpGet("add-nextofkinrecord")]
		public async Task<IActionResult> AddNextOfKinRecord()
		{
			return View();
		}

		[HttpPost("add-nextofkinrecord")]
		public async Task<IActionResult> AddNextOfKinRecord([FromForm] NextOfKinDto request)
		{
			var result = await _nextOfKinService.AddNextOfKinInfo(request);
			if (result.IsSuccessful)
			{
				Url.Action("AddHealthInfo", "HealthInfo");
			}
			return RedirectToAction("AddNextOfKinRecord");
		}

		[HttpGet("update-nextofkin-record/{id}")]
		public async Task<IActionResult> UpdateRecord([FromRoute] Guid id)
		{
			var result = await _nextOfKinService.GetNextOfKinInfo(id);
			return View(result.Data);
		}

		[HttpPost("update-nextofkin-record/{id}")]
		public async Task<IActionResult> UpdateRecord([FromRoute] Guid id, [FromForm] UpdateNextOfKinDto request)
		{
			var result = await _nextOfKinService.UpdateNextOfKin(id, request);
			if (result.IsSuccessful)
			{
				Url.Action("UpdateHealthStatus","HealthStatus", new { id = id });
			}
			return RedirectToAction("EmployeeDetails");
		}

		//[HttpGet("delete-employee/{id}")]
		//public async Task<IActionResult> DeleteNextOfKin([FromRoute] Guid id)
		//{
		//	var result = await _nextOfKinService.Delete(id);
		//	if (result.IsSuccessful)
		//	{
		//		Url.Action("Employee","Employee");
		//	}
		//	return RedirectToAction("Employee");
		//}	
	}
}
