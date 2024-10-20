using FirstMVCProject.Models.Entity;
using FirstMVCProject.Repository.EmployeeRepInterFace;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCProject.Repository.EmploRep
{
	public class NextOfKinRepository : INextOfKinRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public NextOfKinRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<NextOfKin>> GetAllNextOfKinAsync()
		{
			return await _dbContext.NextKin.ToListAsync();
		}
		public async Task<NextOfKin> GetNextOfKinAsync(Guid id)
		{
			return await _dbContext.NextKin.Where(x => x.Id == id).FirstOrDefaultAsync();
		}
		public async Task<NextOfKin?> GetNextOfKinByNameAsync(string FullName)
		{
			return await _dbContext.NextKin.Where(x => x.FullName.ToLower() == FullName.ToLower()).FirstOrDefaultAsync();
		}
	}
}