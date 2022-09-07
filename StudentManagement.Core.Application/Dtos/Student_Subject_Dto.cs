using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentManagement.Core.Application.Dtos
{
    public class Student_Subject_Dto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public double Grade { get; set; }
        [JsonIgnore]
        public string Literal { get; set; }
    }
}
