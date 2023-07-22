using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class RecipeTypeCreateDTO
    {
        public string Name { get; set; }
        public int Locale_id { get; set; }
    }
}
