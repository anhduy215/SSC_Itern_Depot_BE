using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class LocationStatus
    {
        [Key]
        public int LocationStatusID { get; set; }
        public string Status { get; set; }
    }
}

