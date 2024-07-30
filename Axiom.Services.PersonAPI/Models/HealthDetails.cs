using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Axiom.Services.PersonAPI.Models
{
    public class HealthDetails
    {
        [Key]
        [ForeignKey("Person")]
        public long PersonId { get; set; }

        [Required]
        public byte MedicalTreatment { get; set; }

        [StringLength(255)]
        public string? TreatmentDescription { get; set; }

        [Required]
        public byte TakingContinuousMedication { get; set; }

        public List<string>? MedicationsList { get; set; }

        [Required]
        public byte HasAllergies { get; set; }

        public List<string>? AllergiesList { get; set; }

        [Required]
        public PressureLevel PressureLevel { get; set; }

        [Required]
        public byte HadRecentSurgery { get; set; }

        public List<string>? RecentSurgeryList { get; set; }

        [Required]
        public byte HasProsthesisPinPlate { get; set; }

        public List<string>? ProsthesisPinPlateList { get; set; }

        [Required]
        public byte Pregnant { get; set; }

        [Range(0, 40)]
        public int WeeksPregnant { get; set; }

        [Required]
        public byte HighRiskPregnancy { get; set; }

        [Required]
        public byte DoExercises { get; set; }

        public List<string>? ActivityTypes { get; set; }

        public List<string>? WeeklyFrequency { get; set; }

        [Required]
        public byte MakesRepetitiveMovement { get; set; }

        [StringLength(255)]
        public string? Considerations { get; set; }

        public virtual Person Person { get; set; }
    }
}