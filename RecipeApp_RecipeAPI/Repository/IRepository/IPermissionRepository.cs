using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Repository.IRepository
{
    public interface IPermissionRepository : IRepository<Permission>
    {
        Task<Permission> UpdateAsync(Permission entity);
    }
}
