using System.ComponentModel.DataAnnotations;

namespace DepotBackEnd.DTO.Eir
{
    public class CreateEirDTO
    {
        public string CustomerName { get; set; } = string.Empty;
        public string TaxCode { get; set; } = string.Empty;
        public DateTime? Deadline { get; set; }//chọn type out thì hiện
        public DateTime CreateDate { get; set; }//now
        public string EirType { get; set; } = string.Empty;
        public int LineOperatorID { get; set; }
        public string ContainerNumber { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        //userid cho bằng null và approvement cũng vậy
    }
}
