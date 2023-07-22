using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class RecipeReactionCreateDTO
    {
        public int Recepie_id { get; set; }
        public int User_id { get; set; }
        public int Reaction_id { get; set; }
    }
}
