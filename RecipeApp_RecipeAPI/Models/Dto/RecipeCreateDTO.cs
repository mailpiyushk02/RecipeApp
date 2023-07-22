using System.ComponentModel.DataAnnotations;

namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class RecipeCreateDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Introduction { get; set; }
        [Required]
        public int Calories { get; set; }
        [Required]
        public int Servings { get; set; }
        public string Allergens { get; set; }
        public string Allergens_decription { get; set; }
        [Required]
        public int Cook_id { get; set; }
        [Required]
        public int Locale_id { get; set; }
        [Required]
        public int Cooking_time { get; set; }
        [Required]
        public string Youtube_Url { get; set; }
        public string Tags { get; set; }
    }
}
