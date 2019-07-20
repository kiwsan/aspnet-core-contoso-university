using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Domain.Entities
{
    [Table("student")]
    public class Student : Person
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column("enrollment_date")]
        public DateTime EnrollmentAtDate { get; set; }

        public virtual ICollection<Enrollment> TableEnrollments { get; set; }
    }
}