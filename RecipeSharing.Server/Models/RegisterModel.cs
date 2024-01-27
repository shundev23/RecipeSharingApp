using System.ComponentModel.DataAnnotations;

namespace RecipeSharing.Server.Models
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="パスワードと確認用パスワードが一致しません。")]
        public string? ConfirmPassword { get; set;}
    }
}
