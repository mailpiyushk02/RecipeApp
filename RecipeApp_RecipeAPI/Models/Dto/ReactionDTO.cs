using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class ReactionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img_small { get; set; }
        public string Img_large { get; set; }
    }
}
