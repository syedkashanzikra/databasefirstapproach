using System;
using System.Collections.Generic;

namespace DBFirstApproach.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; } = null!;
        public int? ClassId { get; set; }

        public virtual Class? Class { get; set; }
    }
}
