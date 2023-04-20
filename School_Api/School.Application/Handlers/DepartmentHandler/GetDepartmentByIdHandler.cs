using MediatR;
using School_Application.Query.DepartmentQuery;
using School_Application.Query.SchoolQuery;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Handlers.DepartmentHandler
{
    public class GetDepartmentByIdHandler : IRequestHandler<GetDepartmentByIdQuery, Department>
    {

        private readonly IRepository<Department> _repository;
        public GetDepartmentByIdHandler(IRepository<Department> repository)
        {
            _repository = repository;

        }

        public async Task<Department> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var department = await _repository.GetByIdAsync(request.id);
             return department;
        }

    }
}
