using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class CookTimeCreateDTO
    {
        public int Value { get; set; }
        public string Unit { get; set; }
        public int Locale_id { get; set; }
    }
}
