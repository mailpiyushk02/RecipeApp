using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Repository.IRepository;

namespace RecipeApp_RecipeAPI.Repository
{
    public class RecipeIngredientRepository : Repository<RecipeIngredient>, IRecipeIngredientRepository
    {
        private readonly ApplicationDbContext _db;
        public RecipeIngredientRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }
        public async Task<RecipeIngredient> UpdateAsync(RecipeIngredient entity)
        {
            _db.RecipeIngredients.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
