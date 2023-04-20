using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MediatR;
using School_Application.Response.StudentResponse;

namespace School_Application.Commands.StudentCommand
{
    public class CreateStudentCommand : IRequest<AddStudentResponse>
    {
      
        public int Id { get; set; }
        [JsonPropertyName("Enter Student Name")]
        public string? Name { get; set; }
        [JsonPropertyName("Enter Address")]
        public string? Address { get; set; }
        [JsonPropertyName("Enter DOB")]
        public DateTime DOB { get; set; }
        [JsonPropertyName("Enter School ID")]
        public int School_id { get; set; }
        [JsonPropertyName("Enter Department ID")]
        public int Dep_id { get; set; }
      
    }
}
