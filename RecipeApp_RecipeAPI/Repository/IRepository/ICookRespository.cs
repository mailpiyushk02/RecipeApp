using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Repository.IRepository
{
    public interface ICookRespository :IRepository<Cook>
    {
        Task<Cook> UpdateAsync(Cook entity);
    }
}
