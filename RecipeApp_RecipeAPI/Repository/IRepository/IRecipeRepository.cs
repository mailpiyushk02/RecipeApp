using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Repository.IRepository
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<Recipe> UpdateAsync(Recipe entity);
    }
}
