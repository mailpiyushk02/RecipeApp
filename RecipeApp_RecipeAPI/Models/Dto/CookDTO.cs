using System.ComponentModel.DataAnnotations;

namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class CookDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Img_small { get; set; }
        [Required]
        public string Img_large { get; set; }
        [Required]
        public string Youtube_url { get; set; }
    }
}
