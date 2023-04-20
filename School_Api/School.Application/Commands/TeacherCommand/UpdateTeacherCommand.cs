using MediatR;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace School_Application.Commands.TeacherCommand
{
    public class UpdateTeacherCommand : IRequest<Teacher>
    {
        [JsonIgnore]
        public int Id { get; set; }
        [JsonPropertyName("Enter Name")]
        [Required(ErrorMessage = "Teacher name required")]
        public string? Name { get; set; }
        [JsonPropertyName("Enter Age")]
        public int? Age { get; set; }
        [JsonPropertyName("Phone")]
        public string? Phone { get; set; }
        [JsonPropertyName("Enter Email")]
        public string? Email { get; set; }
        [JsonPropertyName("Subject")]
        public string? Subject { get; set; }
        [JsonPropertyName("School Id")]
        public int? School_id { get; set; }
        [JsonPropertyName("Department Id")]
        public int? Dep_id { get; set; }
    }
}
