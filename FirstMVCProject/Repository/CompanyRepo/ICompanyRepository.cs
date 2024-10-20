using FirstMVCProject.Models.Entity;

namespace FirstMVCProject.Repository.CompanyRepo
{
    public interface ICompanyRepository
	{
		Task<CompanyRegistration?> GetCompanyByNameAsync(string CompanyName);
		Task<List<CompanyRegistration>> GetAllCompanyAsync();
		Task<CompanyRegistration> GetCompanyAsync(Guid id);


	}
}
