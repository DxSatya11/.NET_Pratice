using Newtonsoft.Json;
using School_Domain.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace School_Domain.Model
{
    public class Teacher : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Phone { get;set; }
        public string? Email { get;set; }
        public string? Subject { get; set; }
        [ForeignKey("School")]
        [JsonPropertyName("School Id")]
        public int? School_id { get; set; }
     //   [System.Text.Json.Serialization.JsonIgnore]
        public virtual Schools? School { get; set; }
        [ForeignKey("Department")]
        [JsonPropertyName("Department Id")]
        public int? Dep_id { get; set; }
      //  [System.Text.Json.Serialization.JsonIgnore]    
        public virtual Department? Department { get; set; }
    }
}
