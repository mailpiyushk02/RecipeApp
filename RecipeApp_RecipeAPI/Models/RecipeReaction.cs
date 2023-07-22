using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp_RecipeAPI.Models
{
    public class RecipeReaction
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Recipe")]
        public string Recepie_id { get; set; }
        public Recipe Recipe { get; set; }
        [ForeignKey("User")]
        public int User_id { get; set; }
        public User User { get; set; }
        [ForeignKey("Reaction")]
        public int Reaction_id { get; set; }
        public Reaction Reaction { get; set; }
    }
}
