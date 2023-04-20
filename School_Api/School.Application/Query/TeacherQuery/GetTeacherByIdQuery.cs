using MediatR;
using School_Application.Response.TeacherResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Query.TeacherQuery
{
    public class GetTeacherByIdQuery : IRequest<AddTeacherResponse>
    {
        public int id { get; set; }
    }
}
