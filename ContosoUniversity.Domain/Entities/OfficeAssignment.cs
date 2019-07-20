using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContosoUniversity.Domain.Abstracts;

namespace ContosoUniversity.Domain.Entities
{
    [Table("office_assignment")]
    public class OfficeAssignment : BaseEntity
    {
        //[Column("instructor_id")]
        //public Guid InstructorId { get; set; }

        [StringLength(50)]
        [Column("location")]
        public string Location { get; set; }

        //public virtual Instructor TableInstructor { get; set; }
    }
}