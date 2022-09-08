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
        public string StudentName { get; set; }
        public bool Present { get; set; }
        public bool Excuse { get; set; }
        public bool Ausence { get; set; }
    }
}
