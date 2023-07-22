using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class RecipeReactionDTO
    {
        public int Id { get; set; }
        public string Recepie_id { get; set; }
        public int User_id { get; set; }
        public int Reaction_id { get; set; }
    }
}
