using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Repository.IRepository
{
    public interface IRecipeReviewRespository : IRepository<RecipeReview>
    {
        Task<RecipeReview> UpdateAsync(RecipeReview entity);
    }
}
