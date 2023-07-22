using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApp_RecipeAPI.Models
{
    public class RolePermission
    {
        [ForeignKey("Role")]
        public int Role_id { get; set; }
        public Role Role { get; set; }
        [ForeignKey("Permission")]
        public int Permission_id { get; set; }
        public Permission Permission { get; set; }
    }
}
