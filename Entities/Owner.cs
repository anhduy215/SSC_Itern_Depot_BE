using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class Owner
    {
        [Key]
        public int OwnerID { get; set; }
        [Required] 
        public string OwnerName { get; set; } = string.Empty;
        [Required]
        public string OwnerCode { get; set; } = string.Empty;
        public string? ContactInfo { get; set; }
        public string? CompanyName { get; set; }
        public int ContainerCount { get; set; }
    }
}

