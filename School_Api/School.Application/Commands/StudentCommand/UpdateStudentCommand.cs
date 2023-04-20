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

namespace School_Application.Commands.StudentCommand
{
    public class UpdateStudentCommand : IRequest<Student>
    {

        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyName("Student Name")]
        public string? Name { get; set; }
        [JsonPropertyName("Address")]
        public string? Address { get; set; }
        [JsonPropertyName("DOB")]
        public DateTime DOB { get; set; }
        [JsonPropertyName("School Id")]
        public int? School_id { get; set; }
        [JsonPropertyName("Department Id")]
        public int? Dep_id { get; set; }
       
    }
}
