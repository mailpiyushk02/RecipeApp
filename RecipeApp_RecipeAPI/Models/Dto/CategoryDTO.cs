using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img_small { get; set; }
        public string Img_large { get; set; }
        public int Locale_id { get; set; }
        public Locale Locale { get; set; }
    }
}
