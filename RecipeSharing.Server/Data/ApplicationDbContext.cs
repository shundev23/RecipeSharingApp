using Microsoft.EntityFrameworkCore;
using RecipeSharing.Server.Models;

namespace RecipeSharing.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<RecipeModel>Recipes { get; set; }
        public DbSet<UserModel>Users { get; set; }
    }
}
