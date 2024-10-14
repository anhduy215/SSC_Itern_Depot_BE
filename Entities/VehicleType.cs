using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class VehicleType
    {
        [Key]
        public int VehicleTypeID { get; set; }
        [Required]
        public string VehicleTypeName { get; set; } = string.Empty;
    }
}

