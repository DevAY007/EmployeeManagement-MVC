using FirstMVCProject.Dto.EducationHistory;
using FirstMVCProject.Services.EmployeeServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCProject.Controllers
{
	[Route("Add Info")]
	public class EducationInfoController : Controller
	{
		private readonly IEducationHistoryService _eduInfoService;

		public EducationInfoController(IEducationHistoryService eduInfoService)
		{
			_eduInfoService = eduInfoService;
		}

		[HttpGet("edu-info/{id}")]
		public async Task<IActionResult> EduInfoDetailsAsync([FromRoute] Guid id)
		{
			var result = await _eduInfoService.GetEducationInfo(id);
			return View(result.Data);
		}

		[HttpGet("create-eduinfo")]
		public async Task<IActionResult> AddEducationInfo()
		{
			return View();
		}

		[HttpPost("create-eduinfo")]
		public async Task<IActionResult> AddEducationInfo([FromForm] EducationHistoryDto request)
		{
			var result = await _eduInfoService.AddEducationInfo(request);
			if (result.IsSuccessful)
			{
				Url.Action("AddNextOfKinRecord", "NextOfKin");
			}
			return RedirectToAction("AddEducationInfo");
		}

		[HttpGet("update-education-history/{id}")]
		public async Task<IActionResult> UpdateHistory([FromRoute] Guid id)
		{
			var result = await _eduInfoService.GetEducationInfo(id);
			return View(result.Data);
		}

		[HttpPost("update-education-history/{id}")]
		public async Task<IActionResult> UpdateHistory([FromRoute] Guid id, [FromForm] UpdateEducationHistoryDto request)
		{
			var result = await _eduInfoService.UpdateHistory(id, request);
			if (result.IsSuccessful)
			{
				Url.Action("UpdateRecord","NextOfKin", new { id = id });
			}
			return RedirectToAction("EmployeeDetails");
		}

		//[HttpGet("delete-employee/{id}")]
		//public async Task<IActionResult> DeleteEduInfo([FromRoute] Guid id)
		//{
		//	var result = await _eduInfoService.Delete(id);
		//	if (result.IsSuccessful)
		//	{
		//		Url.Action("Employee", "Employee");
		//	}
		//	return RedirectToAction("Employee");
		//}
	}
}
