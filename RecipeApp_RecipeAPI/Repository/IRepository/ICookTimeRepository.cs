using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Repository.IRepository
{
    public interface ICookTimeRepository : IRepository<CookTime>
    {
        Task<CookTime> UpdateAsync(CookTime entity);
    }
}
