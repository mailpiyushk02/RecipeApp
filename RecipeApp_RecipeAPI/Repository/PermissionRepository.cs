using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Repository.IRepository;

namespace RecipeApp_RecipeAPI.Repository
{
    public class PermissionRepository : Repository<Permission>, IPermissionRepository
    {
        private readonly ApplicationDbContext _db;
        public PermissionRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }
        public async Task<Permission> UpdateAsync(Permission entity)
        {
            _db.Permissions.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
