using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class PositionContainer
    {
        [Key]
        public int PositionID { get; set; }
        public string? Status { get; set; }
        public int Bay { get; set; }
        public int RowNumber { get; set; }
        public int TierNumber { get; set; }
        [ForeignKey("Container")]
        public string? ContainerNumber { get; set; }
        [ForeignKey("ContainerBlock")]
        public int BlockID { get; set; }

        public Container? Container { get; set; }
        public Block? Block { get; set; }
    }
}
