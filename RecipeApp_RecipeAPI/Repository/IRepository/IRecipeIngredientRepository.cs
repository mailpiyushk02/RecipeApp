using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Repository.IRepository
{
    public interface IRecipeIngredientRepository : IRepository<RecipeIngredient>
    {
        Task<RecipeIngredient> UpdateAsync(RecipeIngredient entity);
    }
}
