using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class ContainerBlock
    {
        [Key]
        public int BlockID { get; set; }
        public int BayRange { get; set; }
        public int RowRange { get; set; }
        public int TierRange { get; set; }
        public int DepotID { get; set; }
        public Depot Depot { get; set; }
    }
}
