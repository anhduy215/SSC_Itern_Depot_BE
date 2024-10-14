using System.ComponentModel.DataAnnotations.Schema;

namespace DepotBackEnd.DTO.Position
{
    public class CreatePositionDTO
    {
        public string? Status { get; set; }
        public int Bay { get; set; }
        public int RowNumber { get; set; }
        public int TierNumber { get; set; }
        public string ContainerNumber { get; set; } = string.Empty;
        public int BlockID { get; set; }
    }
}
