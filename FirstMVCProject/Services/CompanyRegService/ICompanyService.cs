using FirstMVCProject.Dto.Employees;
using FirstMVCProject.Dto;
using FirstMVCProject.Dto.Company;

namespace FirstMVCProject.Services.CompanyRegService
{
	public interface ICompanyService
	{
		Task<BaseResponse<bool>> CreateCompany(CreateCompanyDto request);
		Task<BaseResponse<List<CompanyRegistrationDto>>> GetAllCompany();
		Task<BaseResponse<CompanyRegistrationDto>> GetCompany(Guid id);
		Task<BaseResponse<bool>> UpdateCompany(Guid id, UpdateCompany request);
		Task<BaseResponse<bool>> Delete(Guid id);
		//Task <BaseResponse<CompanyRegistrationDto>>BackToCompany();
	}
}
