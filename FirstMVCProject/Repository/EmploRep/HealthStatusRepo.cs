using FirstMVCProject.Models.Entity;
using FirstMVCProject.Repository.EmployeeRepInterFace;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCProject.Repository.EmploRep
{
	public class HealthStatusRepo : IHealthStatusRepo
	{
		private readonly ApplicationDbContext _dbContext;

		public HealthStatusRepo(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<HealthStatus>> GetAllInfoAsync()
		{
			return await _dbContext.HealthStatus.ToListAsync();
		}
		public async Task<HealthStatus> GetHealthInfoAsync(Guid id)
		{
			return await _dbContext.HealthStatus.Where(x => x.Id == id).FirstOrDefaultAsync();
		}
		public async Task<HealthStatus?> GetInfoByBloodGroupAsync(string BloodGroup)
		{
			return await _dbContext.HealthStatus.Where(x => x.BloodGroup.ToLower() == BloodGroup.ToLower()).FirstOrDefaultAsync();
		}
	}
}
