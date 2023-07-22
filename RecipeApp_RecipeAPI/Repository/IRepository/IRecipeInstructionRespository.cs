using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Repository.IRepository
{
    public interface IRecipeInstructionRespository : IRepository<RecipeInstruction>
    {
        Task<RecipeInstruction> UpdateAsync(RecipeInstruction entity);
    }
}
