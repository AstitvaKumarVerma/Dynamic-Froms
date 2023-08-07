using System;
using System.Collections.Generic;

namespace DynamicFormAPI.Models
{
    public partial class AstitvaSubjects508
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string SubjectName { get; set; } = null!;
        public int Marks { get; set; }

        public virtual AstitvaStudents508 Student { get; set; } = null!;
    }
}
