using Axiom.Services.PersonAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class PersonDetails
{
    [Key]
    [ForeignKey("Person")]
    public long PersonId { get; set; } 
    public bool ReceivedProfessionalMassage { get; set; }
    public string? PreferredTechniques { get; set; }
    public byte ServiceExpectations { get; set; } 
    public byte PreferredTouchPressure { get; set; } 

    public virtual Person Person { get; set; } 
}