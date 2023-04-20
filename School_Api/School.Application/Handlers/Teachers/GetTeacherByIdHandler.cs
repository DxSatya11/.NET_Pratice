using MediatR;
using School_Application.Mappers;
using School_Application.Query.TeacherQuery;
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
    public class GetTeacherByIdHandler : IRequestHandler<GetTeacherByIdQuery, AddTeacherResponse>
    {
        private readonly IRepository<Teacher> _repository;


        public GetTeacherByIdHandler(IRepository<Teacher> repository)
        {
            _repository = repository;

        }
        public async Task<AddTeacherResponse> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            var department = SchoolMapper.Mapper.Map<Teacher>(request);
            if (department == null)
            {
                throw new ApplicationException("Issue with Mapper");
            }
            var response = (await _repository.GetByIdAsync(request.id, t => t.School, t => t.Department));
            var departmentresponse = SchoolMapper.Mapper.Map<AddTeacherResponse>(response);
            return departmentresponse;
        }
    }
}
