using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class FullStatus
    {
        [Key]
        public int FullStatusID { get; set; }
        [Required]
        public string Status { get; set; } = string.Empty;
    }
}
