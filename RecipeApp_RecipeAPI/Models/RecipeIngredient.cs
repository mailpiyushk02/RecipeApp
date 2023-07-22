using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp_RecipeAPI.Models
{
    public class RecipeIngredient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Recipe")]
        public string Recipe_id { get; set; }
        public Recipe Recipe { get; set; }
        [ForeignKey("Ingredient")]
        public int Ingredient_id { get; set; }
        public Ingredient Ingredient { get; set; }
        public int Quantity{ get; set; }
        public string Quantity_unit { get; set; }
        [ForeignKey("Locale")]
        public int Locale_id { get; set; }
        public Locale Locale { get; set; }
    }
}
