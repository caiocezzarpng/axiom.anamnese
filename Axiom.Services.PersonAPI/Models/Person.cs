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
        public string? Ocuppation { get; set; }
        [Required]
        public string Telephone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FullAddress { get; set; }

        public virtual PersonDetails PersonDetails { get; set; }
        public virtual HealthDetails HealthDetails { get; set; }
    }
}
