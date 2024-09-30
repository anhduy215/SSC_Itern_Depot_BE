using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class ContainerType
    {
        [Key]
        public int TypeID { get; set; }
        public string TypeName { get; set; }
        public string TypeCode { get; set; }
        public string Description { get; set; }
    }
}

