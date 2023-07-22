using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Repository.IRepository
{
    public interface IDietRespository : IRepository<Diet>
    {
        Task<Diet> UpdateAsync(Diet entity);
    }
}
