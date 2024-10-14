using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class LocationStatus
    {
        [Key]
        public int LocationStatusID { get; set; }
        [Required] public string Status { get; set; } = string.Empty;
    }
}

