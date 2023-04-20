using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using School_Application.Response.SchoolResponse;
using School_Application.Response.DepartmentResponse;

namespace School_Application.Response.StudentResponse
{
    public class AddStudentResponse
    {
        public int Id { get; set; }
        [JsonPropertyName("Student Name")]
        public string? Name { get; set; }
        [JsonPropertyName("Address")]
        public string? Address { get; set; }
        [JsonPropertyName("DOB")]
        public DateTime DOB { get; set; }
     //   [ForeignKey("AddSchoolResponse")]
        public int? School_id { get; set; }
        public virtual AddSchoolResponse? School { get; set; }
      //  [ForeignKey("AddDepartmentResponse")]
        public int? Dep_id { get; set; }
        public virtual AddDepartmentResponse? Department { get; set; }
    }
}
