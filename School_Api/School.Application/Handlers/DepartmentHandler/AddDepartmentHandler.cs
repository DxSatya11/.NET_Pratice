using MediatR;
using School_Application.Commands.DepartmentCommand;
using School_Application.Mappers;
using School_Application.Query.DepartmentQuery;
using School_Application.Response.DepartmentResponse;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Handlers.DepartmentHandler
{
    public class AddDepartmentHandler : IRequestHandler<CreateDepartmentCommand, AddDepartmentResponse>
    {
        private readonly IRepository<Department> _repository;
        public AddDepartmentHandler(IRepository<Department> repository)
        {
            _repository = repository;   
        }

        public async Task<AddDepartmentResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = SchoolMapper.Mapper.Map<Department>(request);
                if (department == null)
                {
                    throw new ApplicationException("Issue with Mapper");
                }
                var newdepartment = await _repository.AddAsync(department); 
                var departmentresponse = SchoolMapper.Mapper.Map<AddDepartmentResponse>(newdepartment);
                return departmentresponse;
        }
       
    }
}
