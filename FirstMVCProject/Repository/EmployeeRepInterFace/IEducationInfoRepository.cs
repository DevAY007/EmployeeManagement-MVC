using FirstMVCProject.Models.Entity;

namespace FirstMVCProject.Repository.EmployeeRepInterFace
{
	public interface IEducationInfoRepository
	{
		Task<EducationHistory> GetEducationInfoAsync(Guid id);
		Task<EducationHistory?> GetEducationInfoBySchoolNameAsync(string DateGraduated);
		Task<List<EducationHistory>> GetAllEducationInfoAsync();
	}
}
