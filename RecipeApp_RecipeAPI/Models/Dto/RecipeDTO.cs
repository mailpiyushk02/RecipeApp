using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class RecipeDTO
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Introduction { get; set; }
        public string Image { get; set; }
        public int Calories { get; set; }
        public int Servings { get; set; }
        public string Allergens { get; set; }
        public string Allergens_decription { get; set; }
        public int Cook_id { get; set; }
        public Cook Cook { get; set; }
        public int Locale_id { get; set; }
        public Locale Locale { get; set; }
        public int Cooking_time { get; set; }
        public string Youtube_Url { get; set; }
        public string Tags { get; set; }
    }
}
