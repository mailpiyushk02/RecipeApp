using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Repository.IRepository
{
    public interface IUserRespository : IRepository<User>
    {
        Task<User> UpdateAsync(User entity);
    }
}
