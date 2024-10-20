using FirstMVCProject.Models.Entity;
using FirstMVCProject.Repository.EmployeeRepInterFace;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCProject.Repository.EmploRep
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            return await _dbContext.emlpoyees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(Guid id)
        {
            return await _dbContext.emlpoyees.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Employee?> GetEmployeeByFirstNameAsync(string FirstName)
        {
            return await _dbContext.emlpoyees.Where(x => x.FirstName.ToLower() == FirstName.ToLower()).FirstOrDefaultAsync();
        }
        public async Task<List<Employee>> GetEmployeesByCompanyIdAsync(Guid companyId)
        {
            return await _dbContext.emlpoyees.Where(e => e.CompanyId == companyId).ToListAsync();
        }

    }
}
