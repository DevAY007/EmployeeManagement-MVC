 using FirstMVCProject.Dto;
using FirstMVCProject.Dto.Employees;

namespace FirstMVCProject.Services.EmployeeServiceInterface
{
    public interface IEmployeeService
    {
        Task<BaseResponse<bool>> AddEmployee(AddEmployeeDto request);
        Task<BaseResponse<List<EmployeeDto>>> GetAllEmployee();
        Task<BaseResponse<EmployeeDto>> GetEmployee(Guid id);
        Task<BaseResponse<bool>> UpdateEmployee(Guid id, UpdateEmployeeDto request);
        Task<BaseResponse<bool>> Delete(Guid id);
        Task<BaseResponse<List<EmployeeDto>>> GetAllEmployeesByCompanyId(Guid companyId);
    }
}
