using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class ContainerSize
    {
        [Key]
        public int SizeID { get; set; }
        public int SizeContainer { get; set; }
    }
}
