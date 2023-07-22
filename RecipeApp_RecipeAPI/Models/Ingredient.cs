using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp_RecipeAPI.Models
{
    public class Ingredient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img_small { get; set; }
        public string Img_large { get; set; }
        [ForeignKey("Locale")]
        public int Locale_id { get; set; }
        public Locale Locale { get; set; }
    }
}
