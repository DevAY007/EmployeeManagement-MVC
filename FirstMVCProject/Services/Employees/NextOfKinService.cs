using FirstMVCProject.Dto;
using FirstMVCProject.Models.Entity;
using FirstMVCProject.Repository.EmployeeRepInterFace;
using FirstMVCProject.Services.EmployeeServiceInterface;
using FirstMVCProject.Dto.NextOfKin;

namespace FirstMVCProject.Services.Employees
{
	public class NextOfKinService : INextOfKinService
	{
		private readonly INextOfKinRepository _nextOfKinRepository;
		private readonly ApplicationDbContext _dbContext;

		public NextOfKinService(INextOfKinRepository NextOfKinRepository, ApplicationDbContext dbContext)
		{
			_nextOfKinRepository = NextOfKinRepository;
			_dbContext = dbContext;
		}

		public async Task<BaseResponse<bool>> AddNextOfKinInfo(NextOfKinDto request)
		{
			try
			{
				var nextOfKin = await _nextOfKinRepository.GetNextOfKinByNameAsync(request.FullName);
				if (nextOfKin != null)
				{
					return new BaseResponse<bool> { Message = "Record Already Exist", IsSuccessful = false };
				}

				var newinfo = new NextOfKin()
				{
					FullName = request.FullName,
					Gender = request.Gender,
					PhoneNumber = request.PhoneNumber,
					Gmail = request.Gmail,
					HomeAddress = request.HomeAddress
				};
				await _dbContext.NextKin.AddAsync(nextOfKin);
				if (await _dbContext.SaveChangesAsync() > 0)
				{
					return new BaseResponse<bool> { Message = "NextOfKin Infomation added successfully", IsSuccessful = true, Data = true };
				}
				return new BaseResponse<bool> { Message = "Failed To Add NextOfKin Infomation ", IsSuccessful = false, Data = false };
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = false };
			}
		}

		public async Task<BaseResponse<List<NextOfKinDto>>> GetAllNextOfKinRecord()
		{
			try
			{
				var nextOfKin = await _nextOfKinRepository.GetAllNextOfKinAsync();

				if (nextOfKin.Count > 0)
				{
					var data = nextOfKin.Select(x => new NextOfKinDto
					{
						Id = x.Id,
						FullName = x.FullName,
						Gender = x.Gender,
						PhoneNumber = x.PhoneNumber,
						Gmail = x.Gmail,
						HomeAddress = x.HomeAddress
					}).ToList();
					return new BaseResponse<List<NextOfKinDto>> { Message = "Record retrieved successfully", IsSuccessful = true, Data = data };
				}
				return new BaseResponse<List<NextOfKinDto>> { Message = "No record", IsSuccessful = false, Data = new List<NextOfKinDto>() };
			}
			catch (Exception ex)
			{
				return new BaseResponse<List<NextOfKinDto>> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data = new List<NextOfKinDto>() };
			}
		}

		public async Task<BaseResponse<NextOfKinDto>> GetNextOfKinInfo(Guid id)
		{
			try
			{
				var nextOfKinInfo = await _nextOfKinRepository.GetNextOfKinAsync(id);
				if (nextOfKinInfo != null)
				{
					var data = new NextOfKinDto
					{
						Id = nextOfKinInfo.Id,
						FullName = nextOfKinInfo.FullName,
						Gender = nextOfKinInfo.Gender,
						PhoneNumber = nextOfKinInfo.PhoneNumber,
						Gmail = nextOfKinInfo.Gmail,
						HomeAddress = nextOfKinInfo.HomeAddress
					};
					return new BaseResponse<NextOfKinDto> { Message = "Record Retrived Successfully", IsSuccessful = true, Data = data };
				}
				return new BaseResponse<NextOfKinDto> { Message = "No Record ", IsSuccessful = false, Data = new NextOfKinDto() };

			}
			catch (Exception ex)
			{
				return new BaseResponse<NextOfKinDto> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data = new NextOfKinDto() };
			}
		}

		public async Task<BaseResponse<bool>> UpdateNextOfKin(Guid id, UpdateNextOfKinDto request)
		{
			try
			{
				var nextofkin = await _nextOfKinRepository.GetNextOfKinAsync(id);
				if (nextofkin != null)
				{
					nextofkin.FullName = request.FullName;
					nextofkin.Gender = request.Gender;
					nextofkin.PhoneNumber = request.PhoneNumber;
					nextofkin.Gmail = request.Gmail;
					nextofkin.HomeAddress = request.HomeAddress;

					_dbContext.NextKin.Update(nextofkin);

					if (await _dbContext.SaveChangesAsync() > 0)
					{
						return new BaseResponse<bool> { Message = "Next Of Kin Records updated successfully", IsSuccessful = true, Data = true };
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
				var eduinfo = await _nextOfKinRepository.GetNextOfKinAsync(id);

				if (eduinfo != null)
				{
					_dbContext.NextKin.Remove(eduinfo);

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
