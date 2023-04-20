using MediatR;
using School_Application.Commands.DepartmentCommand;
using School_Application.Commands.StudentCommand;
using School_Application.Mappers;
using School_Application.Response.DepartmentResponse;
using School_Application.Response.StudentResponse;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Handlers.StudentHandler
{
    public class AddStudentHandler : IRequestHandler<CreateStudentCommand, AddStudentResponse>
    {
        private readonly IRepository<Student> _repository;
        private readonly IRepository<Schools> _schoolRepository;
        private readonly IRepository<Department> _departmentRepository;
        public AddStudentHandler(IRepository<Student> repository, IRepository<Schools> schoolRepository, IRepository<Department> departmentRepository)
        {
            _repository = repository;
            _schoolRepository = schoolRepository;
            _departmentRepository = departmentRepository;
        }
        public async Task<AddStudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = SchoolMapper.Mapper.Map<Student>(request);
            if (student == null)
            {
                throw new ApplicationException("Issue with Mapper");
            }

            var school = await _schoolRepository.GetByIdAsync(request.School_id);
            if (school == null)
            {
                student.School_id = null;
              
            }

            var department = await _departmentRepository.GetByIdAsync(request.Dep_id);
            if (department == null)
            {
                // Dep_id is not valid, set it to null
                student.Dep_id = null;
            }
            var newstudent = await _repository.AddAsync(student);
            var response = (await _repository.GetAllAsync(t => t.School, t => t.Department))?.FirstOrDefault(t => t.Id == newstudent?.Id);
            var studentresponse = SchoolMapper.Mapper.Map<AddStudentResponse>(response);
            return studentresponse;
        }
    }
}
