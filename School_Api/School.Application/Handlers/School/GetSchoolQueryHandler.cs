using AutoMapper;
using MediatR;
using School_Application.Mappers;
using School_Application.Query.SchoolQuery;
using School_Application.Response.SchoolResponse;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Handlers.School
{
    public class GetSchoolQueryHandler : IRequestHandler<GetSchoolQuery, IEnumerable<Schools>>
    {
        private readonly IRepository<Schools> _repository;
       

        public GetSchoolQueryHandler(IRepository<Schools> repository)
        {
            _repository = repository;
           
        }

        public async Task<IEnumerable<Schools>> Handle(GetSchoolQuery request, CancellationToken cancellationToken)
        {
            var departmentlist = await _repository.GetAllAsync();
            return departmentlist;
        }
    }
}
