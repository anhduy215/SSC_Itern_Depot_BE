using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class FullStatus
    {
        [Key]
        public int FullStatusID { get; set; }
        public string Status { get; set; }
    }
}
