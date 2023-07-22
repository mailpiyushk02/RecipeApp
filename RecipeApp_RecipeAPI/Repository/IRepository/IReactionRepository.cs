using RecipeApp_RecipeAPI.Models;

namespace RecipeApp_RecipeAPI.Repository.IRepository
{
    public interface IReactionRepository : IRepository<Reaction>
    {
        Task<Reaction> UpdateAsync(Reaction entity);
    }
}
