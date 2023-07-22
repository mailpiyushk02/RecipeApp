using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Repository.IRepository;

namespace RecipeApp_RecipeAPI.Repository
{
    public class CookFollowerRespository : Repository<CookFollower>, ICookFollowerRespository
    {
        private readonly ApplicationDbContext _db;
        public CookFollowerRespository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<CookFollower> UpdateAsync(CookFollower entity)
        {
             _db.CookFollowers.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
