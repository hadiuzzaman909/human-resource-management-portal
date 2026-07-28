using HRMS.Application.DTOs.Request;
using HRMS.Application.DTOs.Response;
using HRMS.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetAll()
    {
        var result = await _employeeService.GetAllEmployeesAsync();
        return Ok(result);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<EmployeeResponse>> GetById(int id)
    {
        var result = await _employeeService.GetEmployeeByIdAsync(id);
        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<EmployeeResponse>> Create([FromBody] EmployeeRequest request)
    {
        var result = await _employeeService.CreateEmployeeAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _employeeService.GetEmployeeByIdAsync(id);
        if (existing == null) return NotFound();

        await _employeeService.DeleteEmployeeAsync(id);
        return NoContent();
    }
}