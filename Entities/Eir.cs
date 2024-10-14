using Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DepotBackEnd.Entities
{
    public class Eir
    {
        [Key]
        public int EirNumber { get; set; }
        [Required] public string TaxCode { get; set; } = string.Empty;
        [Required] public string CustomerName { get; set; } = string.Empty;
        public DateTime? Deadline { get; set; }
        public DateTime CreateDate { get; set; }
        [Required] public string EirType { get; set; } = string.Empty;
        public int LineOperatorID { get; set; }
        [Required] public string ContainerNumber { get; set; } = string.Empty;
        [Required] public string LicensePlate { get; set; } = string.Empty;
        public string? Approvements { get; set; }
        public int? UserID { get; set; }

        [ForeignKey("LineOperatorID")]
        public LineOperator? LineOperator { get; set; }
        [ForeignKey("ContainerNumber")]
        public Container? Container { get; set; }
        [ForeignKey("LicensePlate")]
        public Vehicle? Vehicle { get; set; }
        [ForeignKey("UserID")]
        public UserAccount? UserAccount { get; set; }
    }
}
