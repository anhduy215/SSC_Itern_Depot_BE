using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Vehicle
    {
        [Key]
        [Required] public string LicensePlate { get; set; }= string.Empty;
        [ForeignKey("VehicleType")]
        public int VehicleTypeID { get; set; }

        public VehicleType? VehicleType { get; set; }
    }
}
