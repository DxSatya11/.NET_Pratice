using MediatR;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Query.TeacherQuery
{
    public record GetTeacherQuery : IRequest<IEnumerable<Teacher>>;
   
}
