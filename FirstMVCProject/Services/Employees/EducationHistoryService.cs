using FirstMVCProject.Dto;
using FirstMVCProject.Models.Entity;
using FirstMVCProject.Repository.EmployeeRepInterFace;
using FirstMVCProject.Services.EmployeeServiceInterface;
using FirstMVCProject.Dto.EducationHistory;
using FirstMVCProject.Repository.EmploRep;

namespace FirstMVCProject.Services.Employees
{
	public class EducationHistoryService : IEducationHistoryService
    {
		private readonly IEducationInfoRepository _educationInfoRepository;
		private readonly ApplicationDbContext _dbContext;

		public EducationHistoryService(IEducationInfoRepository educationInfoRepository, ApplicationDbContext dbContext)
		{
			_educationInfoRepository = educationInfoRepository;
			_dbContext = dbContext;
		}

		public async Task<BaseResponse<bool>> AddEducationInfo(EducationHistoryDto request)
		{
			try
			{
				var educationInfo = await _educationInfoRepository.GetEducationInfoBySchoolNameAsync(request.DateGraduated);
				if (educationInfo != null)
				{
					return new BaseResponse<bool> { Message = "Record Already Exist", IsSuccessful = false };
				}

				var newinfo = new EducationHistory()
				{
					PrimarySchoolAttended = request.PrimarySchoolAttended,
					SecondarySchoolAttended = request.SecondarySchoolAttended,
					InstitutionAttended = request.InstitutionAttended,
					Qualification = request.Qualification,
					DateGraduated = request.DateGraduated
				};
				await _dbContext.EduInformation.AddAsync(educationInfo);
				if (await _dbContext.SaveChangesAsync() > 0)
				{
					return new BaseResponse<bool> { Message = "Education Infomation added successfully", IsSuccessful = true, Data = true };
				}
				return new BaseResponse<bool> { Message = "Education Infomation Failed To Add", IsSuccessful = false, Data = false };
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = false };
			}
		}

		public async Task<BaseResponse<List<EducationHistoryDto>>> GetAllEducationInfo()
		{
			try
			{
				var eduInfo = await _educationInfoRepository.GetAllEducationInfoAsync();

				if (eduInfo.Count > 0)
				{
					var data = eduInfo.Select(x => new EducationHistoryDto
					{
						Id = x.Id,
						PrimarySchoolAttended = x.PrimarySchoolAttended,
						SecondarySchoolAttended = x.SecondarySchoolAttended,
						InstitutionAttended = x.InstitutionAttended,
						Qualification = x.Qualification,
						DateGraduated = x.DateGraduated
					}).ToList();
					return new BaseResponse<List<EducationHistoryDto>> { Message = "Record retrieved successfully", IsSuccessful = true, Data = data };
				}
				return new BaseResponse<List<EducationHistoryDto>> { Message = "No record", IsSuccessful = false, Data = new List<EducationHistoryDto>() };
			}
			catch (Exception ex)
			{
				return new BaseResponse<List<EducationHistoryDto>> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data = new List<EducationHistoryDto>() };
			}
		}


		public async Task<BaseResponse<EducationHistoryDto>> GetEducationInfo(Guid id)
		{
			try
			{
				var eduInfo = await _educationInfoRepository.GetEducationInfoAsync(id);
				if (eduInfo != null)
				{
					var data = new EducationHistoryDto
					{
						Id = eduInfo.Id,
						PrimarySchoolAttended = eduInfo.PrimarySchoolAttended,
						SecondarySchoolAttended = eduInfo.SecondarySchoolAttended,
						InstitutionAttended = eduInfo.InstitutionAttended,
						Qualification = eduInfo.Qualification,
						DateGraduated = eduInfo.DateGraduated
					};
					return new BaseResponse<EducationHistoryDto> { Message = "Record Retrived Successfully", IsSuccessful = true, Data = data };
				}
				return new BaseResponse<EducationHistoryDto> { Message = "No Record ", IsSuccessful = false, Data = new EducationHistoryDto() };

			}
			catch (Exception ex)
			{
				return new BaseResponse<EducationHistoryDto> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data = new EducationHistoryDto() };
			}
		}

		public async Task<BaseResponse<bool>> UpdateHistory(Guid id, UpdateEducationHistoryDto request)
		{
			try
			{
				var eduinfo = await _educationInfoRepository.GetEducationInfoAsync(id);
				if (eduinfo != null)
				{
					eduinfo.PrimarySchoolAttended = request.PrimarySchoolAttended;
					eduinfo.SecondarySchoolAttended = request.SecondarySchoolAttended;
					eduinfo.InstitutionAttended = request.InstitutionAttended;
					eduinfo.Qualification = request.Qualification;
					eduinfo.DateGraduated = request.DateGraduated;

					_dbContext.EduInformation.Update(eduinfo);

					if (await _dbContext.SaveChangesAsync() > 0)
					{
						return new BaseResponse<bool> { Message = "Education History updated successfully", IsSuccessful = true, Data = true };
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
				var eduinfo = await _educationInfoRepository.GetEducationInfoAsync(id);

				if (eduinfo != null)
				{
					_dbContext.EduInformation.Remove(eduinfo);

					if (await _dbContext.SaveChangesAsync() > 0)
					{
						return new BaseResponse<bool> { Message = "Employee deleted successfully", IsSuccessful = true, Data = true };
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
