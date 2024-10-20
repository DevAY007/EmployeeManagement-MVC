using FirstMVCProject.Dto.Company;
using FirstMVCProject.Dto;
using FirstMVCProject.Models.Entity;
using FirstMVCProject.Repository.CompanyRepo;

namespace FirstMVCProject.Services.CompanyRegService
{
	public class CompanyService : ICompanyService
	{
		private readonly ICompanyRepository _companyRepository;
		private readonly ApplicationDbContext _applicationDbContext;

		public CompanyService(ICompanyRepository companyRepository, ApplicationDbContext applicationDbContext)
		{
			_companyRepository = companyRepository;
			_applicationDbContext = applicationDbContext;
		}

		public async Task<BaseResponse<bool>> CreateCompany(CreateCompanyDto request)
		{
			try
			{
				var company = await _companyRepository.GetCompanyByNameAsync(request.CompanyName);
				if (company != null)
				{
					return new BaseResponse<bool> { Message = "Company Record Already Exist", IsSuccessful = false };
				}

				var newCompany = new CompanyRegistration()
				{
					CompanyName = request.CompanyName,
					CompanyEmail = request.CompanyEmail,
					About = request.About
				};
				await _applicationDbContext.CompanyRegistration.AddAsync(newCompany);
				if (await _applicationDbContext.SaveChangesAsync() > 0)
				{
					return new BaseResponse<bool> { Message = "Company Created successfully", IsSuccessful = true, Data = true };
				}
				return new BaseResponse<bool> { Message = "Company Creation Failed", IsSuccessful = false, Data = false };
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool> { Message = $"Error: {ex.Message}", IsSuccessful = false, Data = false };
			}
		}

		public async Task<BaseResponse<List<CompanyRegistrationDto>>> GetAllCompany()
		{
			try
			{
				var company = await _companyRepository.GetAllCompanyAsync();

				if (company.Count > 0)
				{
					var data = company.Select(x => new CompanyRegistrationDto
					{
						CompanyId = x.Id,
						CompanyName = x.CompanyName,
						CompanyEmail = x.CompanyEmail,
						About = x.About
					}).ToList();
					return new BaseResponse<List<CompanyRegistrationDto>> { Message = "Record retrieved successfully", IsSuccessful = true, Data = data };
				}
				return new BaseResponse<List<CompanyRegistrationDto>> { Message = "No record", IsSuccessful = false, Data = new List<CompanyRegistrationDto>() };
			}
			catch (Exception ex)
			{
				return new BaseResponse<List<CompanyRegistrationDto>> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data = new List<CompanyRegistrationDto>() };
			}
		}

		public async Task<BaseResponse<CompanyRegistrationDto>> GetCompany(Guid id)
		{
			try
			{
				var company = await _companyRepository.GetCompanyAsync(id);
				if (company != null)
				{
					var data = new CompanyRegistrationDto
					{
						CompanyId = company.Id,
						CompanyName = company.CompanyName,
						CompanyEmail = company.CompanyEmail,
						About = company.About,
					};
					return new BaseResponse<CompanyRegistrationDto> { Message = "Company Record Retrived Successfully", IsSuccessful = true, Data = data };
				}
				return new BaseResponse<CompanyRegistrationDto> { Message = "No Record ", IsSuccessful = false, Data = new CompanyRegistrationDto() };

			}
			catch (Exception ex)
			{
				return new BaseResponse<CompanyRegistrationDto> { Message = $"Error : {ex.Message}", IsSuccessful = false, Data = new CompanyRegistrationDto() };
			}
		}

		public async Task<BaseResponse<bool>> UpdateCompany(Guid id, UpdateCompany request)
		{
			try
			{
				var company = await _companyRepository.GetCompanyAsync(id);
				if (company != null)
				{
					company.CompanyName = request.CompanyName;
					company.CompanyEmail = request.CompanyEmail;
					company.About = request.About;

					_applicationDbContext.CompanyRegistration.Update(company);

					if (await _applicationDbContext.SaveChangesAsync() > 0)
					{
						return new BaseResponse<bool> { Message = "Company Record updated successfully", IsSuccessful = true, Data = true };
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
				var company = await _companyRepository.GetCompanyAsync(id);

				if (company != null)
				{
					_applicationDbContext.CompanyRegistration.Remove(company);

					if (await _applicationDbContext.SaveChangesAsync() > 0)
					{
						return new BaseResponse<bool> { Message = "Company Record Deleted Successfully", IsSuccessful = true, Data = true };
					}
				}
				return new BaseResponse<bool> { Message = "Book not found", IsSuccessful = false, Data = false };
				
			}
			catch (Exception ex)
			{
				return new BaseResponse<bool> { Message = $"Error :  {ex.Message}", IsSuccessful = false, Data = false };
			}
		}
		/*
		public async Task<BaseResponse<CompanyRegistrationDto>> BackToCompany()
		{
			try
			{
				var company = await _companyRepository.
			}
		}*/

    }
}
