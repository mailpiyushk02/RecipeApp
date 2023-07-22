using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp_RecipeAPI.Models
{
    public class Cook
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img_small { get; set; }
        public string Img_large { get; set; }
        public string Youtube_url { get; set; }
    }
}
