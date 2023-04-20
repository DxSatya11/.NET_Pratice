using School_Domain.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace School_Domain.Model
{
    public class Department : IEntity
    {
        [Key]
        public int Id { get; set; }
        [JsonPropertyName("Department Name")]
        public string? Name { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Student>? Student { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Teacher>? Teacher { get; set; }


    }
}
