using System.ComponentModel.DataAnnotations;

namespace Entity {
    public class Depot
    {
        [Key]
        public int DepotID { get; set; }
        public string DepotName { get; set; }
        public string Location { get; set; }
        public int BlockCapacity { get; set; }
        public string Contact { get; set; }
    }
}
