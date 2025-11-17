using App.Client.DAL.Models;
using App.Client.PL.Dtos;
using AutoMapper;

namespace App.Client.PL.Mapping {
    public class EmployeeProfile : Profile {

        public EmployeeProfile() {

            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<Employee, CreateEmployeeDto>();
                //.ForMember(d => d.DepartmentName,
                //o => o.MapFrom(s => s.Department.Name));



            // In case there are different variable names
            //CreateMap<CreateEmployeeDto, Employee>()
            //    .ForMember(d => d.Name,
            //    o => o.MapFrom(s => s.EmpName));
            //CreateMap<Employee, CreateEmployeeDto>()
            //.ForMember(e => e.EmpName, o =>
            //o.MapFrom(s => s.Name));

        }

    }
}
