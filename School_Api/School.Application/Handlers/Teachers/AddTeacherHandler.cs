using MediatR;
using School_Application.Commands.TeacherCommand;
using School_Application.Mappers;
using School_Application.Response.StudentResponse;
using School_Application.Response.TeacherResponse;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Handlers.Teachers
{
    public class AddTeacherHandler : IRequestHandler<CreateTeacherCommand, AddTeacherResponse>
    {
        private readonly IRepository<Teacher> _repository;
        private readonly IRepository<Schools> _schoolRepository;
        private readonly IRepository<Department> _departmentRepository;
        public AddTeacherHandler(IRepository<Teacher> repository, IRepository<Schools> schoolRepository, IRepository<Department> departmentRepository)
        {
            _repository = repository;   
            _schoolRepository = schoolRepository;
            _departmentRepository = departmentRepository;
        }

        public async Task<AddTeacherResponse> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = SchoolMapper.Mapper.Map<Teacher>(request);
            if (teacher == null)
            {
                throw new ApplicationException("Issue with Mapper");
            }

            var school = await _schoolRepository.GetByIdAsync(request.School_id);
            if (school == null)
            {
                teacher.School_id = null;
            }

            var department = await _departmentRepository.GetByIdAsync(request.Dep_id);
            if (department == null)
            {
                // Dep_id is not valid, set it to null
                teacher.Dep_id = null;
            }

            var newteacher = await _repository.AddAsync(teacher);
           // var response = await _repository.GetDataById(newteacher.Id);
            var response = (await _repository.GetAllAsync(t => t.School, t => t.Department)).FirstOrDefault(t => t.Id == newteacher.Id);    

            var teacherresponse = SchoolMapper.Mapper.Map<AddTeacherResponse>(response);
            return teacherresponse;
        }
    }
}
