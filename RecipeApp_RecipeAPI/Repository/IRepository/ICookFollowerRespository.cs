using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Repository.IRepository
{
    public interface ICookFollowerRespository : IRepository<CookFollower>
    {
        Task<CookFollower> UpdateAsync(CookFollower entity);
    }
}
