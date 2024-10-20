﻿using FirstMVCProject.Models.Entity;

namespace FirstMVCProject.Repository.EmployeeRepInterFace
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeAsync(Guid id);
        Task<Employee?> GetEmployeeByFirstNameAsync(string FirstName);
        Task<List<Employee>> GetAllEmployeeAsync();
        Task<List<Employee>> GetEmployeesByCompanyIdAsync(Guid companyId);
    }
}
