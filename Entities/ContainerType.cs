using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class ContainerType
    {
        [Key]
        public int TypeID { get; set; }
        [Required] public string TypeName { get; set; } = string.Empty;
        [Required] public string TypeCode { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}

