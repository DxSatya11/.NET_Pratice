using MediatR;
using School_Application.Response.DepartmentResponse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace School_Application.Commands.DepartmentCommand
{
    public class CreateDepartmentCommand : IRequest<AddDepartmentResponse>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [Required(ErrorMessage = "Department Name Required")]
        [JsonPropertyName("Department Name")]
        public string? Name { get; set; }
    }
}
