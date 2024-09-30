using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class LifeCycle
    {
        [Key]
        public int LifeCycleID { get; set; }
        public int ContainerNumber { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }

        public Container Container { get; set; }
    }
}
