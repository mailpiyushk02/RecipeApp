using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp_RecipeAPI.Models
{
    public class CookFollower
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Cook")]
        public int Cook_id { get; set; }
        public Cook Cook { get; set; }
        [ForeignKey("User")]
        public int User_id { get; set; }
        public User User { get; set; }

    }
}
