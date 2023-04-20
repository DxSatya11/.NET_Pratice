using AutoMapper;
using School_Application.Commands.DepartmentCommand;
using School_Application.Commands.SchoolCommand;
using School_Application.Commands.StudentCommand;
using School_Application.Commands.TeacherCommand;
using School_Application.Query.StudentQuery;
using School_Application.Query.TeacherQuery;
using School_Application.Response.DepartmentResponse;
using School_Application.Response.SchoolResponse;
using School_Application.Response.StudentResponse;
using School_Application.Response.TeacherResponse;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Mappers
{
    public class SchoolMappingProfil : Profile
    {
        public SchoolMappingProfil() 
        {
            CreateMap<Schools, SchoolCommand>().ReverseMap();
            CreateMap<Schools, AddSchoolResponse>().ReverseMap();
            CreateMap<Schools, DeleteSchoolCommand>().ReverseMap();
            CreateMap<Schools, DeleteSchoolResponse>().ReverseMap();

            CreateMap<Department, CreateDepartmentCommand>().ReverseMap();
            CreateMap<Department, AddDepartmentResponse>().ReverseMap();
            CreateMap<Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Student, AddStudentResponse>().ReverseMap();
            CreateMap<Teacher, CreateTeacherCommand>().ReverseMap();
            CreateMap<Teacher, AddTeacherResponse>().ReverseMap();
            CreateMap<GetStudentByIdQuery, Student>();
            CreateMap<GetTeacherByIdQuery, Teacher>();
            CreateMap<Schools, UpdateSchoolCommand>().ReverseMap(); 
          //  CreateMap<Student,UpdateStudentCommand>().ReverseMap(); 

        }
        
    }
}
