using MediatR;
using School_Application.Query.StudentQuery;
using School_Application.Query.TeacherQuery;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Handlers.Teachers
{
    public class GetTeacherHandler : IRequestHandler<GetTeacherQuery, IEnumerable<Teacher>>
    {
        private readonly IRepository<Teacher> _repository;  
        public GetTeacherHandler(IRepository<Teacher> repository)
        {
            _repository = repository;   
        }  
        public async Task<IEnumerable<Teacher>> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
        {
            var teacher = await _repository.GetAllAsync(t => t.School, t => t.Department);
            return teacher;
        }
    }
}
