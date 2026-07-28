using HRMS.Application.DTOs.Request;
using HRMS.Application.DTOs.Response;

namespace HRMS.Application.Services;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeResponse>> GetAllEmployeesAsync();
    Task<EmployeeResponse?> GetEmployeeByIdAsync(int id);
    Task<EmployeeResponse> CreateEmployeeAsync(EmployeeRequest request);
    Task DeleteEmployeeAsync(int id);
}