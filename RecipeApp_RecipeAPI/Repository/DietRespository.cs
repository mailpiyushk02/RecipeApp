using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Repository.IRepository;

namespace RecipeApp_RecipeAPI.Repository
{
    public class DietRespository : Repository<Diet>, IDietRespository
    {
        private readonly ApplicationDbContext _db;
        public DietRespository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Diet> UpdateAsync(Diet entity)
        {
             _db.Diets.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
