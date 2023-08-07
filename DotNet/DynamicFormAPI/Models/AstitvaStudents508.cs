using System;
using System.Collections.Generic;

namespace DynamicFormAPI.Models
{
    public partial class AstitvaStudents508
    {
        public AstitvaStudents508()
        {
            AstitvaSubjects508s = new HashSet<AstitvaSubjects508>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;

        public virtual ICollection<AstitvaSubjects508> AstitvaSubjects508s { get; set; }
    }
}
