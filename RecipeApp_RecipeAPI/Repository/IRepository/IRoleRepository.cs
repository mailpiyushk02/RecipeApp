using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Repository.IRepository
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> UpdateAsync(Role entity);
    }
}
