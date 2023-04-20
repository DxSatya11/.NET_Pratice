using MediatR;
using School_Application.Query.SchoolQuery;
using School_Application.Query.StudentQuery;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace School_Application.Handlers.StudentHandler
{
    public class GetStudentHandler : IRequestHandler<GetStudentQuery, IEnumerable<Student>>
    {
        private readonly IRepository<Student> _repository;
        public GetStudentHandler(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Student>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var studentlist = await _repository.GetAllAsync();
            return studentlist; 
        }
    }
}
