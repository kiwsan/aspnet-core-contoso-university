using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContosoUniversity.Domain.Abstracts;

namespace ContosoUniversity.Domain.Entities
{
    [Table("department")]
    public class Department : BaseEntity
    {
        [StringLength(50, MinimumLength = 3)]
        [Column("name")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        [Column("budget")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column("start_date")]
        public DateTime StartAtDate { get; set; }

        [Column("instructor_id")]
        public Guid? InstructorId { get; set; }

        public virtual Instructor TableInstructor { get; set; }

        public virtual ICollection<Course> TableCourses { get; set; }
    }
}