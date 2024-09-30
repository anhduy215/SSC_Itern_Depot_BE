using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class Ship
    {
        [Key]
        public int ShipID { get; set; }
        public string ShipName { get; set; }
        public string Status { get; set; }
    }
}

