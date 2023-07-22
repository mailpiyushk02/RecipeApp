using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp_RecipeAPI.Models
{
    public class Recipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = "";
        public string Title { get; set; }
        public string Introduction { get; set; }
        public string Image { get; set; }
        public int Calories { get; set; }
        public int Servings { get; set; }
        public string Allergens { get; set; }
        public string Allergens_decription { get; set; }
        [ForeignKey("Cook")]
        public int Cook_id { get; set; }
        public Cook Cook { get; set; }
        [ForeignKey("Locale")]
        public int Locale_id { get; set; }
        public Locale Locale { get; set; }
        public int Cooking_time { get; set; }
        public string Youtube_url { get; set; }
        public string Tags { get; set; }

        public void GenerateNewId(string prefix)
        {
            this.Id = string.Format("{0}_{1}", prefix, Guid.NewGuid().ToString("N"));
        }

    }
}
