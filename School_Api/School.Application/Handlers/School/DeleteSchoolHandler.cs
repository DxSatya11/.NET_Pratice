using MediatR;
using School_Application.Commands.SchoolCommand;
using School_Application.Mappers;
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
    public class DeleteSchoolHandler : IRequestHandler<DeleteSchoolCommand, DeleteSchoolResponse>
    {
        private readonly IRepository<Schools> _repository;

        public DeleteSchoolHandler(IRepository<Schools> repository)
        {
            _repository = repository;
        }

        public Task<DeleteSchoolResponse> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
