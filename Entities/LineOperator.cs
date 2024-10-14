using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class LineOperator
    {
        [Key]
        public int LineOperatorID { get; set; }
        [Required] public string LineOperatorName { get; set; } = string.Empty;
        [Required] public string LineOperatorCode { get; set; } = string.Empty;
        public string? ContactInfo { get; set; }
        public string? CompanyName { get; set; }
        public int ActiveContracts { get; set; }
    }
}
