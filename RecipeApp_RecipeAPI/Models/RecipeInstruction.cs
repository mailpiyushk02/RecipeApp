using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp_RecipeAPI.Models
{
    public class RecipeInstruction
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Recipe")]
        public string Recipe_id { get; set; }
        public Recipe Recipe { get; set; }
        public int Step_no { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Img_small { get; set; }
        public string Img_large { get; set; }
        [ForeignKey("Locale")]
        public int Locale_id { get; set; }
        public Locale Locale { get; set; }
    }
}
