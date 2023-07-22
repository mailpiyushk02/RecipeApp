using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Repository.IRepository;

namespace RecipeApp_RecipeAPI.Repository
{
    public class UserRespository : Repository<User>, IUserRespository
    {
        private readonly ApplicationDbContext _db;
        public UserRespository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<User> UpdateAsync(User entity)
        {
             _db.Users.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
