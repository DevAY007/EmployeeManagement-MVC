using FirstMVCProject.Dto;
using FirstMVCProject.Dto.HealthStatus;

namespace FirstMVCProject.Services.EmployeeServiceInterface
{
	public interface IHealthStatus
	{
		Task<BaseResponse<bool>> AddHealthStatusInfo(HealthStatusDto request);
		Task<BaseResponse<List<HealthStatusDto>>> GetAllHealthStatusInfo();
		Task<BaseResponse<HealthStatusDto>> GetHealthStatusInfo(Guid id);
		Task<BaseResponse<bool>> UpdateStatus(Guid id, UpdateHealthStatusDto request);
		Task<BaseResponse<bool>> Delete(Guid id);

	}
}
