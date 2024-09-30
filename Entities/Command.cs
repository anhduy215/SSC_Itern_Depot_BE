using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Command
    {
        [Key]
        public int CommandID { get; set; }
        public string TaxCode { get; set; }
        public string MovementType { get; set; }
        public string CustomerName { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? ContainerQuantity { get; set; }
        public int LineOperatorID { get; set; }
        public int VoyageID { get; set; }

        public LineOperator LineOperator { get; set; }
        public Voyage Voyage { get; set; }
    }
}