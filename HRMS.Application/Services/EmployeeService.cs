using AutoMapper;
using HRMS.Application.Common.Interfaces;
using HRMS.Application.DTOs.Request;
using HRMS.Application.DTOs.Response;
using HRMS.Domain.Entities;

namespace HRMS.Application.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeResponse>> GetAllEmployeesAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<EmployeeResponse>>(employees);
    }

    public async Task<EmployeeResponse?> GetEmployeeByIdAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        if (employee == null) return null;

        return _mapper.Map<EmployeeResponse>(employee);
    }

    public async Task<EmployeeResponse> CreateEmployeeAsync(EmployeeRequest request)
    {
        var employee = _mapper.Map<Employee>(request);
        var created = await _employeeRepository.AddAsync(employee);
        return _mapper.Map<EmployeeResponse>(created);
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        await _employeeRepository.DeleteAsync(id);
    }
}