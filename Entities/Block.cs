using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity {
    public class Block
    {
        [Key]
        public int BlockID { get; set; }
        public int BayRange { get; set; }
        public int RowRange { get; set; }
        public int TierRange { get; set; }
        public int DepotID { get; set; }
        [ForeignKey("DepotID")]
        public Depot? Depot { get; set; }
    }
}
