using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ContosoUniversity.Domain.Abstracts;

namespace ContosoUniversity.Domain.Entities
{
    [Table("person")]
    public class Person: BaseEntity
    {
        [StringLength(50)]
        [Column("last_name")]
        public string LastName { get; set; }

        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("first_name")]
        public string FirstName { get; set; }

        public string FullName
            => LastName + ", " + FirstName;
    }
}