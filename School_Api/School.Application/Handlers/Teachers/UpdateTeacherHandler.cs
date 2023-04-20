using MediatR;
using School_Application.Commands.TeacherCommand;
using School_Domain.IRepository;
using School_Domain.Model;
using School_Ifrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Handlers.Teachers
{
    public class UpdateTeacherHandler : IRequestHandler<UpdateTeacherCommand, Teacher>
    {
        private readonly IRepository<Teacher> _repository;
        private readonly SchooldbContext _schooldbContext;

        public UpdateTeacherHandler(IRepository<Teacher> repository, SchooldbContext schooldbContext)
        {
            _repository = repository;
            _schooldbContext = schooldbContext;
        }


        public async Task<Teacher> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacher = _schooldbContext.teacher.Where(a => a.Id == request.Id).FirstOrDefault();
            if (teacher == null)
            {
                return default;
            }
            else
            {
                teacher.Name = request.Name;
                teacher.Age = request.Age;
                teacher.Phone = request.Phone;  
                teacher.Email = request.Email;
                teacher.School_id = request.School_id;  
                teacher.Dep_id = request.Dep_id;    
                await _schooldbContext.SaveChangesAsync();
                return teacher;

            }
                
        }
    }
}
