using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp_RecipeAPI.Models
{
    public class RecipeReview
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        [ForeignKey("User")]
        public int User_id { get; set; }
        public User User { get; set; }
    }
}
