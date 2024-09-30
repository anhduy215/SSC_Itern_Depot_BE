using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class VehicleType
    {
        [Key]
        public int VehicleTypeID { get; set; }
        public string VehicleTypeName { get; set; }
    }
}

