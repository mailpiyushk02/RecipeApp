using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class RecipeIngredientDTO
    {
        public int Id { get; set; }
        public string Recipe_id { get; set; }
        public int Ingredient_id { get; set; }
        public int Quantity { get; set; }
        public string Quantity_unit { get; set; }
        public int Locale_id { get; set; }
    }
}
