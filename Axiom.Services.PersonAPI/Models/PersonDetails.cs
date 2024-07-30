using Axiom.Services.PersonAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PersonDetails
{
    [Key]
    [ForeignKey("Person")]
    public long PersonId { get; set; }

    [Required]
    public bool ReceivedProfessionalMassage { get; set; }

    public string? PreferredTechniques { get; set; }

    [Required]
    public ServiceExpectations ServiceExpectations { get; set; }

    [Required]
    public TouchPressure PreferredTouchPressure { get; set; }

    public virtual Person Person { get; set; }
}
