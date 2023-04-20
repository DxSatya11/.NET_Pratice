using MediatR;
using School_Application.Query.DepartmentQuery;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Handlers.DepartMentHandler
{
    public class GetDepartmentHandler : IRequestHandler<GetDepartmentQuery, IEnumerable<Department>>
    {
        private readonly IRepository<Department> _repository;   

        public GetDepartmentHandler(IRepository<Department> repository) 
        {
            _repository = repository;   
        }   
        public async Task<IEnumerable<Department>> Handle(GetDepartmentQuery request, CancellationToken cancellationToken)
        {
            var departmentlist = await _repository.GetAllAsync();
            return departmentlist;  
        }
    }
}
