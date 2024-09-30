using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }
        public string LicensePlate { get; set; }
        public string DriverName { get; set; }
        public string DriverContact { get; set; }
        public int? VehicleCapacity { get; set; }
        public string CompanyName { get; set; }
        public string Status { get; set; }
        public int VehicleTypeID { get; set; }

        public VehicleType VehicleType { get; set; }
    }
}
