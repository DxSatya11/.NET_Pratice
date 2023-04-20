using MediatR;
using School_Application.Response.SchoolResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Commands.SchoolCommand
{
    public class DeleteSchoolCommand : IRequest<DeleteSchoolResponse>
    {
        public List<int> Ids { get; set; }
    }
}
