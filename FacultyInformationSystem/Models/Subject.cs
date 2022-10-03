﻿using System;
using System.Collections.Generic;

#nullable disable

namespace FacultyInformationSystem.Models
{
    public partial class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int DeptId { get; set; }

        public virtual Department Dept { get; set; }
    }
}
