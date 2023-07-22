using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Repository.IRepository;

namespace RecipeApp_RecipeAPI.Repository
{
    public class CookRespository : Repository<Cook>, ICookRespository
    {
        private readonly ApplicationDbContext _db;
        public CookRespository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Cook> UpdateAsync(Cook entity)
        {
             _db.Cooks.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
