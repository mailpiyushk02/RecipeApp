using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Repository.IRepository;

namespace RecipeApp_RecipeAPI.Repository
{
    public class RecipeInstructionRespository : Repository<RecipeInstruction>, IRecipeInstructionRespository
    {
        private readonly ApplicationDbContext _db;
        public RecipeInstructionRespository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<RecipeInstruction> UpdateAsync(RecipeInstruction entity)
        {
             _db.RecipeInstructions.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
