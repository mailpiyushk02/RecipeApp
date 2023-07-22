using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class CookFollowerDTO
    {
        public int Id { get; set; }
        public int Cook_id { get; set; }
        public int User_id { get; set; }
    }
}
