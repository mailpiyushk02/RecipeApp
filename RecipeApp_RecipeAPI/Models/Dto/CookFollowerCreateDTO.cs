namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class CookFollowerCreateDTO
    {
        public int Id { get; set; }
        public int Cook_id { get; set; }
        public int User_id { get; set; }
    }
}
