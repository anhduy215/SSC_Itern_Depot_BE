using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }
        [Required] public string UserName { get; set; } = string.Empty;
        [Required] public string UserPassword { get; set; } = string.Empty;
    }
}
