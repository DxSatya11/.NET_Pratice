using Microsoft.EntityFrameworkCore;
using School_Domain.IRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace School_Domain.Model
{
    public class Student :IEntity
    {

        [Key]
        public int Id { get; set; }
        [JsonPropertyName("Student Name")]
        public string? Name { get; set; }
        [JsonPropertyName("Address")]
        public string? Address { get; set; }
        [JsonPropertyName("DOB")]
        [JsonConverter(typeof(JsonDateConverter))]
        public DateTime DOB { get; set; }
        [ForeignKey("School")]
        [JsonPropertyName("School Id")]
        public int? School_id { get; set; }
        [JsonIgnore]
        public virtual Schools? School { get; set; }
        [ForeignKey("Department")]
        [JsonPropertyName("Department Id")]
        public int? Dep_id { get; set; }
        [JsonIgnore]
        public virtual Department? Department { get; set; }


    }

    public class JsonDateConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.Date.ToString("dd-MM-yyy"));
        }

    }
}
