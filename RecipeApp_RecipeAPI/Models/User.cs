using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp_RecipeAPI.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone_no { get; set; }
        public string Email { get; set; }

        public int Role_id { get; set; }
        [ForeignKey("Locale")]
        public int Locale_id { get; set; }
        public Locale Locale { get; set; }

    }
}
