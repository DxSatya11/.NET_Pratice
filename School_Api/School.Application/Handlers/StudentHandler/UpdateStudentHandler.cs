using MediatR;
using School_Application.Commands.DepartmentCommand;
using School_Application.Commands.StudentCommand;
using School_Domain.IRepository;
using School_Domain.Model;
using School_Ifrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Handlers.StudentHandler
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Student>
    {
        private readonly IRepository<Department> _repository;
        private readonly SchooldbContext _schooldbContext;

        public UpdateStudentHandler(IRepository<Department> repository, SchooldbContext schooldbContext)
        {
            _repository = repository;
            _schooldbContext = schooldbContext;
        }
        public async Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _schooldbContext.student.Where(a => a.Id == request.Id).FirstOrDefault();
            if (student == null)
            {
                return default;

            }
            else
            {
                student.Name = request.Name;
                student.Address = request.Address;
                student.DOB = request.DOB;  
                student.School_id = request.School_id;  
                student.Dep_id = request.Dep_id;    
                await _schooldbContext.SaveChangesAsync();
                return student;
            }
        }
    }
}
