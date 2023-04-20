using MediatR;
using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.Extensions.Localization;
using School_Application.Commands.SchoolCommand;
using School_Application.Mappers;
using School_Application.Response.SchoolResponse;
using School_Domain.IRepository;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Handlers.School
{
    public class AddSchoolHandler : IRequestHandler<SchoolCommand, AddSchoolResponse>
    {
        private readonly IRepository<Schools> _repository;
        private readonly IStringLocalizer<AddSchoolHandler> _localizer;
        public AddSchoolHandler(IRepository<Schools> repository, IStringLocalizer<AddSchoolHandler> localizer)
        {
            _repository = repository;
            _localizer = localizer; 
        }
        public async Task<AddSchoolResponse> Handle(SchoolCommand request, CancellationToken cancellationToken)
        {
            var employee = SchoolMapper.Mapper.Map<Schools>(request);
            if (employee == null)
            {
                throw new ApplicationException("Issue with Mapper");
            }
            var newschool = await _repository.AddAsync(employee);
            var schoolResponse = new AddSchoolResponse
            {
                Id = newschool.Id,
                Name = newschool.Name,
                //Message = "School Added successfully"
                Message = _localizer["School Added successfully"].Value
            };
           // var schoolresponse = SchoolMapper.Mapper.Map<AddSchoolResponse>(newschool);
            return schoolResponse;
        }
    }
}
