using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeSharing.Server.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required]
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public  DateOnly BirthDay { get; set; }
    }
}
