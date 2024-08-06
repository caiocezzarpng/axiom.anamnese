using Axiom.Anamnese.Web.Models.Enum;

namespace Axiom.Anamnese.Web.Models.Dto
{
    public class HealthDetailsDto
    {
        public long PersonId { get; set; }
        public byte MedicalTreatment { get; set; }
        public string? TreatmentDescription { get; set; }
        public byte TakingContinuousMedication { get; set; }
        public List<string>? MedicationsList { get; set; }
        public byte HasAllergies { get; set; }
        public List<string>? AllergiesList { get; set; }
        public PressureLevel PressureLevel { get; set; }
        public byte HadRecentSurgery { get; set; }
        public List<string>? RecentSurgeryList { get; set; }
        public byte HasProsthesisPinPlate { get; set; }
        public List<string>? ProsthesisPinPlateList { get; set; }
        public byte Pregnant { get; set; }
        public int WeeksPregnant { get; set; }
        public byte HighRiskPregnancy { get; set; }
        public byte DoExercises { get; set; }
        public List<string>? ActivityTypes { get; set; }
        public List<string>? WeeklyFrequency { get; set; }
        public byte MakesRepetitiveMovement { get; set; }
        public string? Considerations { get; set; }
    }
}