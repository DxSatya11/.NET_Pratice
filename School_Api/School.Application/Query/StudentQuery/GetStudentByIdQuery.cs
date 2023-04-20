using MediatR;
using School_Application.Response.StudentResponse;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Query.StudentQuery
{
    public class GetStudentByIdQuery : IRequest<AddStudentResponse>
    {
        public int Id { get; set; }
    }
}
