using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class ContStatus
    {
        [Key]
        public int StatusID { get; set; }
        public string ContainerStatus { get; set; }
    }
}

