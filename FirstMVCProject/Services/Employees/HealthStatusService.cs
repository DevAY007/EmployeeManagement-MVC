using FirstMVCProject.Dto;
using FirstMVCProject.Dto.HealthStatus;
using FirstMVCProject.Models.Entity;
using FirstMVCProject.Repository.EmploRep;
using FirstMVCProject.Repository.EmployeeRepInterFace;
using FirstMVCProject.Services.EmployeeServiceInterface;

namespace FirstMVCProject.Services.Employees
{
	public class HealthStatusService : IHealthStatus
	{
		private readonly IHealthStatusRepo _healthStatusRepository;
		private readonly ApplicationDbContext _dbContext;

		public HealthStatusService(IHealthStatusRepo HealthStatusRepository, ApplicationDbContext dbContext)
		{
			_healthStatusRepository = HealthStatusRepository;
			_dbContext = dbContext;
		}
		public async Task<BaseResponse<bool>> AddHealthStatusInfo(HealthStatusDto request)
		{
			try
			{
				var healthStatus = await _healthStatusRepository.GetInfoByBloodGroupAsync(request.BloodGroup);
				if (healthStatus != null)
				{
					return new BaseResponse<bool> { Message = "Record Already Exist", IsSuccessful = false };
				}

				var newinfo = new HealthStatus()
				{
					BloodGroup = request.BloodGroup,
					BloodType = request.BloodType,
					Allergies = request.Allergies,
					Precautions = request.Precautions,
					Comment = request.Comment
				};
				await _dbContext.HealthStatus.AddAsync(healthStatus);
				if (await _dbContext.SaveChangesAsync() > 0)
				{
					return new BaseResponse<bool> { Message = "HealthStatus added successfully", IsSuccessful = true, Data = true };
				}
				return new BaseResponse<bool> { Message = "Failed To Add HealthStatus", IsSuccessful = false, Data = false };
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = false };
			}
		}

		public async Task<BaseResponse<List<HealthStatusDto>>> GetAllHealthStatusInfo()
		{
			try
			{
				var healthStatuse = await _healthStatusRepository.GetAllInfoAsync();

				if (healthStatuse.Count > 0)
				{
					var data = healthStatuse.Select(x => new HealthStatusDto
					{
						Id = x.Id,
						BloodGroup = x.BloodGroup,
						BloodType = x.BloodType,
						Allergies = x.Allergies,
						Precautions = x.Precautions,
						Comment = x.Comment
					}).ToList();
					return new BaseResponse<List<HealthStatusDto>> { Message = "Record retrieved successfully", IsSuccessful = true, Data = data };
				}
				return new BaseResponse<List<HealthStatusDto>> { Message = "No record", IsSuccessful = false, Data = new List<HealthStatusDto>() };
			}
			catch (Exception ex)
			{
				return new BaseResponse<List<HealthStatusDto>> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data = new List<HealthStatusDto>() };
			}
		}

		public async Task<BaseResponse<HealthStatusDto>> GetHealthStatusInfo(Guid id)
		{
			try
			{
				var healthStatus = await _healthStatusRepository.GetHealthInfoAsync(id);
				if (healthStatus != null)
				{
					var data = new HealthStatusDto
					{
						Id = healthStatus.Id,
						BloodGroup = healthStatus.BloodGroup,
						BloodType = healthStatus.BloodType,
						Allergies = healthStatus.Allergies,
						Precautions = healthStatus.Precautions,
						Comment = healthStatus.Comment
					};
					return new BaseResponse<HealthStatusDto> { Message = "Record Retrived Successfully", IsSuccessful = true, Data = data };
				}
				return new BaseResponse<HealthStatusDto> { Message = "No Record ", IsSuccessful = false, Data = new HealthStatusDto() };

			}
			catch (Exception ex)
			{
				return new BaseResponse<HealthStatusDto> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data = new HealthStatusDto() };
			}
		}

		public async Task<BaseResponse<bool>> UpdateStatus(Guid id, UpdateHealthStatusDto request)
		{
			try
			{
				var healthstatus = await _healthStatusRepository.GetHealthInfoAsync(id);
				if (healthstatus != null)
				{
					healthstatus.BloodGroup = request.BloodGroup;
					healthstatus.BloodType = request.BloodType;
					healthstatus.Allergies = request.Allergies;
					healthstatus.Precautions = request.Precautions;
					healthstatus.Comment = request.Comment;

					_dbContext.HealthStatus.Update(healthstatus);

					if (await _dbContext.SaveChangesAsync() > 0)
					{
						return new BaseResponse<bool> { Message = "Health Status updated successfully", IsSuccessful = true, Data = true };
					}
				}

				return new BaseResponse<bool> { Message = "Record not found", IsSuccessful = false, Data = false };
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool> { Message = $"Error :  {ex.Message}", IsSuccessful = false, Data = false };
			}
		}

		public async Task<BaseResponse<bool>> Delete(Guid id)
		{
			try
			{
				var healthStatus = await _healthStatusRepository.GetHealthInfoAsync(id);

				if (healthStatus != null)
				{
					_dbContext.HealthStatus.Remove(healthStatus);

					if (await _dbContext.SaveChangesAsync() > 0)
					{
						return new BaseResponse<bool> { Message = "Record deleted successfully", IsSuccessful = true, Data = true };
					}
				}

				return new BaseResponse<bool> { Message = "Employee not found", IsSuccessful = false, Data = false };
			}
			catch (Exception ex)
			{

				return new BaseResponse<bool> { Message = $"Error :  {ex.Message}", IsSuccessful = false, Data = false };
			}
		}
	}
}
