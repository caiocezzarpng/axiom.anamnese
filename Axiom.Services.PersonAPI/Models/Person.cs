using System.ComponentModel.DataAnnotations;

namespace Axiom.Services.PersonAPI.Models
{
    public class Person
    {
        [Key]
        public long PersonId { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string Ocuppation { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string FullAddress { get; set; }

        public virtual PersonDetails PersonDetails { get; set; }
    }
}
