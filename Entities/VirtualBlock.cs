using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity {
    public class VirtualBlock
    {
        [Key]
        public int VirtualBlockID { get; set; }
        [Required] public string BlockName { get; set; } = string.Empty;
        public string? Description { get; set; }
        [ForeignKey("Depot")]
        public int DepotID { get; set; }
        public Depot? Depot { get; set; }
    }
}
