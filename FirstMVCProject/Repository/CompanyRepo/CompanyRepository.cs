using FirstMVCProject.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCProject.Repository.CompanyRepo
{
    public class CompanyRepository :ICompanyRepository
	{
		private readonly ApplicationDbContext _dbContext;
			
		public CompanyRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<CompanyRegistration?> GetCompanyByNameAsync (string CompanyName)
		{
			return await _dbContext.CompanyRegistration.Where(x => x.CompanyName.ToLower() == CompanyName.ToLower()).FirstOrDefaultAsync();
		}

		public async Task<List<CompanyRegistration>> GetAllCompanyAsync()
		{
			return await _dbContext.CompanyRegistration.ToListAsync();
		}
		public async Task<CompanyRegistration> GetCompanyAsync(Guid id)
		{
			return await _dbContext.CompanyRegistration.Where(x => x.Id == id).FirstOrDefaultAsync();
		}
	}
}
