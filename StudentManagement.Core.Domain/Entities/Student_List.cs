using StudentManagement.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Core.Domain.Entities
{
    public class Student_List : AuditableBaseEntity
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public bool Present { get; set; }
        public bool Excuse { get; set; }
        public bool Ausence { get; set; }
    }
}
