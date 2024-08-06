namespace Axiom.Services.PersonAPI.Models.Dto
{
    public class PersonDto
    {
        public long PersonId { get; set; }
        public string Name { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string Ocuppation { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string FullAddress { get; set; }

        public PersonDetailsDto PersonDetails { get; set; }
        public HealthDetailsDto HealthDetails { get; set; }
    }
}