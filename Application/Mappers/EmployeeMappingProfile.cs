using Application.Commands;
using Application.Queries;
using Application.Responses;
using AutoMapper;
using Core.Entities;

namespace Application.Mappers
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeResponse>().ReverseMap();
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, GetAllEmployeeQuery>().ReverseMap();
        }
    }
}