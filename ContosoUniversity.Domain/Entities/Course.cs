using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContosoUniversity.Domain.Abstracts;

namespace ContosoUniversity.Domain.Entities
{
    [Table("course")]
    public class Course : BaseEntity
    {
        [Column("code")]
        public string Code { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Column("title")]
        public string Title { get; set; }

        [Range(0, 5)]
        [Column("credits")]
        public int Credits { get; set; }

        [Column("department_id")]
        public Guid DepartmentId { get; set; }

        public virtual Department TableDepartment { get; set; }

        public virtual ICollection<Enrollment> TableEnrollments { get; set; }

        public virtual ICollection<CourseAssignment> TableCourseAssignments { get; set; }
    }
}