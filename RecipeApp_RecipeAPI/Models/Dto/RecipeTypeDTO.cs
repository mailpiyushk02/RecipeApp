using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class RecipeTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Locale_id { get; set; }
    }
}
