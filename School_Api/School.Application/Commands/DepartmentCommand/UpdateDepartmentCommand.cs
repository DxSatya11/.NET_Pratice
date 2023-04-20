using MediatR;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace School_Application.Commands.DepartmentCommand
{
    public class UpdateDepartmentCommand : IRequest<Department>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyName("Department Name")]
        public string? Name { get; set; }
    }
}
