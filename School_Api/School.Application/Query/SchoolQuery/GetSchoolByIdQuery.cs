using MediatR;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Application.Query.SchoolQuery
{
    public class GetSchoolByIdQuery : IRequest<Schools>
    {
        public int id { get; set; }
    }
   
}
