using System;
using System.ComponentModel.DataAnnotations.Schema;
using ContosoUniversity.Domain.Abstracts;

namespace ContosoUniversity.Domain.Entities
{
    [Table("course_assignment")]
    public class CourseAssignment : BaseEntity
    {
        [Column("instructor_id")]
        public Guid InstructorId { get; set; }

        [Column("course_id")]
        public Guid CourseId { get; set; }

        public virtual Instructor TableInstructor { get; set; }

        public virtual Course TableCourse { get; set; }
    }
}