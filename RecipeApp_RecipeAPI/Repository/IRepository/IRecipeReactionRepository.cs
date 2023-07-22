using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Repository.IRepository
{
    public interface IRecipeReactionRepository : IRepository<RecipeReaction>
    {
        Task<RecipeReaction> UpdateAsync(RecipeReaction entity);
    }
}
