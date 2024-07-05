namespace Axiom.Services.PersonAPI.Models.DTOs
{
    public class PersonDetailsDTO
    {
        public int PersonId { get; set; }
        public bool ReceivedProfessionalMassage { get; set; }
        public string? PreferredTechniques { get; set; }
        public byte ServiceExpectations { get; set; }
        public byte PreferredTouchPressure { get; set; }
    }
}
