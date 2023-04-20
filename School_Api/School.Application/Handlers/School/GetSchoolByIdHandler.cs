using MediatR;
using School_Application.Query.SchoolQuery;
using School_Domain.IRepository;
using School_Domain.Model;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Handlers.School
{
    public class GetSchoolByIdHandler : IRequestHandler<GetSchoolByIdQuery, Schools>
    {
        private readonly IRepository<Schools> _repository;


        public GetSchoolByIdHandler(IRepository<Schools> repository)
        {
            _repository = repository;

        }

        public async Task<Schools> Handle(GetSchoolByIdQuery request, CancellationToken cancellationToken)
        {
            var school = await _repository.GetByIdAsync(request.id);
           
            return school;
        }

    }
}
