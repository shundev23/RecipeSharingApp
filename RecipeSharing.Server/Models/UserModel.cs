using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace RecipeSharing.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string? Password { get; set; }
        public  DateOnly BirthDay { get; set; }
    }
}
