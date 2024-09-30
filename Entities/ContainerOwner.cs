using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class ContainerOwner
    {
        [Key]
        public int OwnerID { get; set; }
        public string OwnerName { get; set; }
        public string OwnerCode { get; set; }
        public string ContactInfo { get; set; }
        public string CompanyName { get; set; }
        public int ContainerCount { get; set; }
    }
}

