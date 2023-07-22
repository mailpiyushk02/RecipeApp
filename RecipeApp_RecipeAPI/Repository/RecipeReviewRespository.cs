using RecipeApp_RecipeAPI.Data;
using RecipeApp_RecipeAPI.Models;
using RecipeApp_RecipeAPI.Repository.IRepository;

namespace RecipeApp_RecipeAPI.Repository
{
    public class RecipeReviewRespository : Repository<RecipeReview>, IRecipeReviewRespository
    {
        private readonly ApplicationDbContext _db;
        public RecipeReviewRespository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public async Task<RecipeReview> UpdateAsync(RecipeReview entity)
        {
             _db.RecipeReviews.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
