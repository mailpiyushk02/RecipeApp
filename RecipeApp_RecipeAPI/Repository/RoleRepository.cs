using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Repository.IRepository;

namespace RecipeApp_RecipeAPI.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly ApplicationDbContext _db;
        public RoleRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }
        public async Task<Role> UpdateAsync(Role entity)
        {
            _db.Roles.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
