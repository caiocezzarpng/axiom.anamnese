using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Axiom.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
    }
}
