using MediatR;
using School_Application.Mappers;
using School_Application.Query.StudentQuery;
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
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, AddStudentResponse>
    {
        private readonly IRepository<Student> _repository;


        public GetStudentByIdHandler(IRepository<Student> repository)
        {
            _repository = repository;

        }

        public async Task<AddStudentResponse> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = SchoolMapper.Mapper.Map<Student>(request);
            if (department == null)
            {
                throw new ApplicationException("Issue with Mapper");
            }
            var response = (await _repository.GetByIdAsync(request.Id, t => t.School, t => t.Department));
            var departmentresponse = SchoolMapper.Mapper.Map<AddStudentResponse>(response);
            return departmentresponse;
        }

    }
}
