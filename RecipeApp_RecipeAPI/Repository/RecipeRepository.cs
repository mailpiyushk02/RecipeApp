using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Repository.IRepository;

namespace RecipeApp_RecipeAPI.Repository
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        private readonly ApplicationDbContext _db;
        public RecipeRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }
        public async Task<Recipe> UpdateAsync(Recipe entity)
        {
            _db.Recipes.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
