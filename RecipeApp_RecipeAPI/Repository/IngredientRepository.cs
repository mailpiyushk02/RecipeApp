using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Repository.IRepository;

namespace RecipeApp_RecipeAPI.Repository
{
    public class IngredientRepository : Repository<Ingredient>, IIngredientRepository
    {
        private readonly ApplicationDbContext _db;
        public IngredientRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }
        public async Task<Ingredient> UpdateAsync(Ingredient entity)
        {
            _db.Ingredients.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
