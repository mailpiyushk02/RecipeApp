namespace RecipeApp_RecipeAPI.Models.Dto
{
    public class UserCreateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone_no { get; set; }
        public string Email { get; set; }

        public int Role_id { get; set; }
        public int Locale_id { get; set; }
    }
}
