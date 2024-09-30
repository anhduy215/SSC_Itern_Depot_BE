using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class VirtualBlock
    {
        [Key]
        public int VirtualBlockID { get; set; }
        public string BlockName { get; set; }
        public string Description { get; set; }
        public int DepotID { get; set; }
        public Depot Depot { get; set; }
    }
}
