using System;
using System.Text.Json.Serialization;

namespace StudentManagement.Core.Application.Dtos
{
    public class Student_List_Dto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        [JsonIgnore]
        public string StudentName { get; set; }
        public bool Present { get; set; } = false;
        public bool Excuse { get; set; } = false;
        public bool Ausence { get; set; } = false;
        public DateTime Created { get; set; }
    }
}
