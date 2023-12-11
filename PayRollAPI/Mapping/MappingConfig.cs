using AutoMapper;
using PayRoll.Application.DTOs;
using PayRoll.Core.Model;

namespace PayRollAPI.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            //department
            CreateMap<Department,DepartmentDTO>().ReverseMap();
            CreateMap<Department, CreateDepartmentDTO>().ReverseMap();

            //employee
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, CreateEmployeeDTO>().ReverseMap();
        }
    }
}
