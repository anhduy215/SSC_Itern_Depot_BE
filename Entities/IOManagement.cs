using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class IOManagement
    {
        [Key]
        public int ManageID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? VehicleID { get; set; }
        public int? ContainerNumber { get; set; }
        public int? CommandID { get; set; }
        public int? UserID { get; set; }
        public Vehicle Vehicle { get; set; }
        public Container Container { get; set; }
        public Command Command { get; set; }
        public UserAccount UserAccount { get; set; }
    }
}
