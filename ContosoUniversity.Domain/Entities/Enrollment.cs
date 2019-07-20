using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContosoUniversity.Domain.Abstracts;
using ContosoUniversity.Domain.Enums;

namespace ContosoUniversity.Domain.Entities
{
    [Table("enrollment")]
    public class Enrollment : BaseEntity
    {
        [DisplayFormat(NullDisplayText = "No Grade")]
        [Column("grade")]
        public Grade? Grade { get; set; }

        [Column("course_id")]
        public Guid CourseId { get; set; }

        [Column("student_id")]
        public Guid StudentId { get; set; }

        public virtual Course TableCourse { get; set; }

        public virtual Student TableStudent { get; set; }
    }
}