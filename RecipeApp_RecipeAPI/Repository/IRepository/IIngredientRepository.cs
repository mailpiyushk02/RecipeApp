using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Repository.IRepository
{
    public interface IIngredientRepository : IRepository<Ingredient>
    {
        Task<Ingredient> UpdateAsync(Ingredient entity);
    }
}
