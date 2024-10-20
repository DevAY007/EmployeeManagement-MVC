using FirstMVCProject.Dto;
using FirstMVCProject.Dto.NextOfKin;

namespace FirstMVCProject.Services.EmployeeServiceInterface
{
	public interface INextOfKinService
	{
		Task<BaseResponse<bool>> AddNextOfKinInfo(NextOfKinDto request);
		Task<BaseResponse<List<NextOfKinDto>>> GetAllNextOfKinRecord();
		Task<BaseResponse<NextOfKinDto>> GetNextOfKinInfo(Guid id);
		Task<BaseResponse<bool>> UpdateNextOfKin(Guid id, UpdateNextOfKinDto request);
		Task<BaseResponse<bool>> Delete(Guid id);
	}
}
