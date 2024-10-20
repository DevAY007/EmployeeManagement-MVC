using FirstMVCProject.Models.Entity;

namespace FirstMVCProject.Repository.EmployeeRepInterFace
{
	public interface IHealthStatusRepo
	{
		Task<HealthStatus> GetHealthInfoAsync(Guid id);
		Task<HealthStatus?> GetInfoByBloodGroupAsync(string BloodGroup);
		Task<List<HealthStatus>> GetAllInfoAsync();
	}
}
