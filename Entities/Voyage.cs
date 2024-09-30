using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Voyage
    {
        [Key]
        public int VoyageID { get; set; }
        public string VoyageNumber { get; set; }
        public int ShipID { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public Ship Ship { get; set; }
    }
}
