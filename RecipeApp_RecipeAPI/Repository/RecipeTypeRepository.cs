using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Repository.IRepository;

namespace RecipeApp_RecipeAPI.Repository
{
    public class RecipeTypeRepository : Repository<RecipeType>, IRecipeTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public RecipeTypeRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }
        public async Task<RecipeType> UpdateAsync(RecipeType entity)
        {
            _db.RecipeTypes.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
