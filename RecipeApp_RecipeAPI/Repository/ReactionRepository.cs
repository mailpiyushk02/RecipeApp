using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Repository.IRepository;

namespace RecipeApp_RecipeAPI.Repository
{
    public class ReactionRepository : Repository<Reaction>, IReactionRepository
    {
        private readonly ApplicationDbContext _db;
        public ReactionRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }
        public async Task<Reaction> UpdateAsync(Reaction entity)
        {
            _db.Reactions.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
