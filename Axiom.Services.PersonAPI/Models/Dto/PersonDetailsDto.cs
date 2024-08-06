namespace Axiom.Services.PersonAPI.Models.Dto
{
    public class PersonDetailsDto
    {
        public int PersonId { get; set; }
        public bool ReceivedProfessionalMassage { get; set; }
        public string? PreferredTechniques { get; set; }
        public ServiceExpectations ServiceExpectations { get; set; }
        public TouchPressure PreferredTouchPressure { get; set; }
    }
}
