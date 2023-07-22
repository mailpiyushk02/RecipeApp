using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp_RecipeAPI.Models
{
    public class CookTime
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Value { get; set; }
        public string Unit { get; set; }
        [ForeignKey("Locale")]
        public int Locale_id { get; set; }
        public Locale Locale { get; set; }
    }
}
