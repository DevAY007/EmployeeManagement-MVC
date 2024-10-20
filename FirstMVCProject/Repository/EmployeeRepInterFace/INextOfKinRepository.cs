using FirstMVCProject.Models.Entity;

namespace FirstMVCProject.Repository.EmployeeRepInterFace
{
	public interface INextOfKinRepository
	{
		Task<NextOfKin> GetNextOfKinAsync(Guid id);
		Task<NextOfKin?> GetNextOfKinByNameAsync(string FirstName);
		Task<List<NextOfKin>> GetAllNextOfKinAsync();
	}
}
