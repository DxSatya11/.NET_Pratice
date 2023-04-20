using MediatR;
using School_Application.Commands.DepartmentCommand;
using School_Domain.IRepository;
using School_Domain.Model;
using School_Ifrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Handlers.DepartmentHandler
{
    public class UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentCommand, Department>
    {
        private readonly IRepository<Department> _repository;
        private readonly SchooldbContext _schooldbContext;

        public UpdateDepartmentHandler(IRepository<Department> repository, SchooldbContext schooldbContext)
        {
            _repository = repository;
            _schooldbContext = schooldbContext;
        }
        public async Task<Department> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var department = _schooldbContext.department.Where(a => a.Id == request.Id).FirstOrDefault();
            if (department == null)
            {
                return default;
            }
            else
            {
                department.Name = request.Name;
                await _schooldbContext.SaveChangesAsync();
                return department;
            }
            
        }
    }
}
