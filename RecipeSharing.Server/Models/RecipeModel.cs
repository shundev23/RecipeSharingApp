using System;
using System.ComponentModel.DataAnnotations;

namespace RecipeSharing.Server.Models
{
    public class RecipeModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Ingredient { get; set; }
        public string? Instructions { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
