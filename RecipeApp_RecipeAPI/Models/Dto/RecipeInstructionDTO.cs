using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class RecipeInstructionDTO
    {
        public int Id { get; set; }
        public string Recipe_id { get; set; }
        public int Step_no { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Img_small { get; set; }
        public string Img_large { get; set; }
        public int Locale_id { get; set; }
    }
}
