using System;
using System.Collections.Generic;

namespace EFDBFirst.Data.Models
{
    public partial class EmployeeEducation
    {
        public EmployeeEducation()
        {
            InverseEmployee = new HashSet<EmployeeEducation>();
        }

        public int Id { get; set; }
        public byte[] CourseName { get; set; } = null!;
        public byte[] UniversityName { get; set; } = null!;
        public int PassingYear { get; set; }
        public int MarksPercentage { get; set; }
        public int EmployeeId { get; set; }

        public virtual EmployeeEducation Employee { get; set; } = null!;
        public virtual ICollection<EmployeeEducation> InverseEmployee { get; set; }
    }
}
