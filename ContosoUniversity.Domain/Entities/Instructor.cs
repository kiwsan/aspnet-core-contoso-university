using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Domain.Entities
{
    [Table("instructor")]
    public class Instructor : Person
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column("hire_date")]
        public DateTime HireAtDate { get; set; }

        //[Column("office_assignment_id")] public Guid OfficeAssignmentId { get; set; }

        public virtual ICollection<CourseAssignment> TableCourseAssignments { get; set; }
        
        public virtual ICollection<Department> TableDepartments { get; set; }

        //public virtual OfficeAssignment TableOfficeAssignment { get; set; }
    }
}