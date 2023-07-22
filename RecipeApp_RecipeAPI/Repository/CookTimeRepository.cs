using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Repository.IRepository;

namespace RecipeApp_RecipeAPI.Repository
{
    public class CookTimeRepository : Repository<CookTime>, ICookTimeRepository
    {
        private readonly ApplicationDbContext _db;
        public CookTimeRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }
        public async Task<CookTime> UpdateAsync(CookTime entity)
        {
            _db.CookTimes.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
