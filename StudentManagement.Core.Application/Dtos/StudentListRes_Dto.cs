using System;
using System.Text.Json.Serialization;

namespace StudentManagement.Core.Application.Dtos
{
    public class StudentListRes_Dto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public bool Present { get; set; } = false;
        public bool Excuse { get; set; } = false;
        public bool Ausence { get; set; } = false;
        public bool StudentExist { get; set; }
        public DateTime Created { get; set; }
    }
}
