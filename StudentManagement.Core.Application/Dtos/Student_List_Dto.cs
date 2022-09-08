using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Application.Dtos
{
    public class Student_List_Dto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public bool Present { get; set; } = false;
        public bool Excuse { get; set; } = false;
        public bool Ausence { get; set; } = false;
        public DateTime Created { get; set; }
    }
}
