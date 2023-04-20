using MediatR;
using School_Application.Commands.SchoolCommand;
using School_Application.Response.SchoolResponse;
using School_Domain.IRepository;
using School_Domain.Model;
using School_Ifrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Handlers.School
{
    public class UpdateSchoolHandler : IRequestHandler<UpdateSchoolCommand, Schools>
    {
        private readonly IRepository<Schools> _repository;
        private readonly SchooldbContext _schooldbContext;

        public UpdateSchoolHandler(IRepository<Schools> repository, SchooldbContext schooldbContext)
        {
            _repository = repository;
            _schooldbContext = schooldbContext; 
        }
      

        public async Task<Schools> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
        {
            var school = _schooldbContext.schools.Where(a => a.Id == request.id).FirstOrDefault();
            if (school == null)
            {
                return default;

            }
            else
            {
                school.Name = request.Name;
                await _schooldbContext.SaveChangesAsync();
                return school;
            }
        }
    }
}
   