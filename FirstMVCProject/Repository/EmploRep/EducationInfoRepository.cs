using FirstMVCProject.Models.Entity;
using FirstMVCProject.Repository.EmployeeRepInterFace;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCProject.Repository.EmploRep
{
	public class EducationInfoRepository : IEducationInfoRepository
	{
		private readonly ApplicationDbContext _dbContext;

		public EducationInfoRepository(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<List<EducationHistory>> GetAllEducationInfoAsync()
		{
			return await _dbContext.EduInformation.ToListAsync();
		}
		public async Task<EducationHistory> GetEducationInfoAsync(Guid id)
		{
			return await _dbContext.EduInformation.Where(x => x.Id == id).FirstOrDefaultAsync();
		}
		public async Task<EducationHistory?> GetEducationInfoBySchoolNameAsync(string DateGraduated)
		{
			return await _dbContext.EduInformation.Where(x => x.DateGraduated.ToLower() == DateGraduated.ToLower()).FirstOrDefaultAsync();
		}
	}
}
