using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class RecipeReviewCreateDTO
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int User_id { get; set; }

    }
}
