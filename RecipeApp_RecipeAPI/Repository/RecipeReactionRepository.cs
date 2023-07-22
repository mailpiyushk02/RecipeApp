using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Repository.IRepository;

namespace RecipeApp_RecipeAPI.Repository
{
    public class RecipeReactionRepository : Repository<RecipeReaction>, IRecipeReactionRepository
    {
        private readonly ApplicationDbContext _db;
        public RecipeReactionRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }
        public async Task<RecipeReaction> UpdateAsync(RecipeReaction entity)
        {
            _db.RecipeReactions.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
