using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}
