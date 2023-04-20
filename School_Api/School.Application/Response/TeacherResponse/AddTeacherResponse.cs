using School_Application.Response.DepartmentResponse;
using School_Application.Response.SchoolResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace School_Application.Response.TeacherResponse
{
    public class AddTeacherResponse 
    {

        [JsonPropertyName("Enter Name")]
        public string? Name { get; set; }
        [JsonPropertyName("Enter Age")]
        public int Age { get; set; }
        [JsonPropertyName("Phone")]
        public string? Phone { get; set; }
        [JsonPropertyName("Enter Email")]
        public string? Email { get; set; }
        [JsonPropertyName("Subject")]
        public string? Subject { get; set; }
        public int School_id { get; set; }
        public virtual AddSchoolResponse? School { get; set; }
        public int Dep_id { get; set; }
        public virtual AddDepartmentResponse? Department { get; set; }
    }
}
