using MediatR;
using School_Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace School_Application.Response.SchoolResponse
{
    public class AddSchoolResponse
    {

        public int Id { get; set; }
        [JsonPropertyName("School Name")]
        public string? Name { get; set; }
        public string? Message { get; set; }
    }
}
