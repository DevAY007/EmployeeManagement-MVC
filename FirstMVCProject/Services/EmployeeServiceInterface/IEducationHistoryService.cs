using FirstMVCProject.Dto;
using FirstMVCProject.Dto.EducationHistory;

namespace FirstMVCProject.Services.EmployeeServiceInterface
{
    public interface IEducationHistoryService
	{
		Task<BaseResponse<bool>> AddEducationInfo(EducationHistoryDto request);
		Task<BaseResponse<List<EducationHistoryDto>>> GetAllEducationInfo();
		Task<BaseResponse<EducationHistoryDto>> GetEducationInfo(Guid id);
		Task<BaseResponse<bool>> UpdateHistory(Guid id, UpdateEducationHistoryDto request);
		Task<BaseResponse<bool>> Delete(Guid id);
	}
}
