namespace Axiom.Services.PersonAPI.Models.DTOs
{
    public class PersonDTO
    {
        public long PersonId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string Ocuppation { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string FullAddress { get; set; }

        public PersonDetailsDTO PersonDetails { get; set; }
    }
}