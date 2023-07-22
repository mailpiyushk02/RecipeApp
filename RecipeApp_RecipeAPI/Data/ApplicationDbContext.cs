using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeType> RecipeTypes { get; set; }
        public DbSet<CookTime> CookTimes { get; set; }
        public DbSet<RecipeReaction> RecipeReactions { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<RecipeReview> RecipeReviews { get; set; }
        public DbSet<RecipeInstruction> RecipeInstructions { get; set; }
        public DbSet<Cook> Cooks { get; set; }
        public DbSet<Locale> Locales { get; set; }
        public DbSet<CookFollower> CookFollowers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var addedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity);

            foreach (var entity in addedEntities)
            {
                var entityType = entity.GetType();
                var tableName = entityType.Name;
                ((Recipe)entity).GenerateNewId(tableName);
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
