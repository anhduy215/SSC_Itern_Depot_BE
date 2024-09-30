using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class LineOperator
    {
        [Key]
        public int LineOperatorID { get; set; }
        public string LineOperatorName { get; set; }
        public string LineOperatorCode { get; set; }
        public string ContactInfo { get; set; }
        public string CompanyName { get; set; }
        public int ActiveContracts { get; set; }
    }
}
