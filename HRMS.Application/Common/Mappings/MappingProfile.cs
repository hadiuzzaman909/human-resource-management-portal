using AutoMapper;
using HRMS.Application.DTOs.Request;
using HRMS.Application.DTOs.Response;
using HRMS.Domain.Entities;

namespace HRMS.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Entity -> Response DTO
        CreateMap<Employee, EmployeeResponse>();

        // Request DTO -> Entity
        CreateMap<EmployeeRequest, Employee>()
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));
    }
}