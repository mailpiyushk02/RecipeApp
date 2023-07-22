using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Repository.IRepository
{
    public interface IRecipeTypeRepository : IRepository<RecipeType>
    {
        Task<RecipeType> UpdateAsync(RecipeType entity);
    }
}
