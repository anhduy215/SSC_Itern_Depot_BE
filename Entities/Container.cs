using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Container
    {
        [Key]
        public int ContainerNumber { get; set; }
        public string? ISO { get; set; }
        public decimal MaximumWeight { get; set; }
        public decimal TareWeight { get; set; }
        public DateTime? DateOfManufacture { get; set; }
        [ForeignKey("ContainerSize")]
        public int SizeID { get; set; }
        [ForeignKey("ContainerStatus")]
        public int ContainerStatusID { get; set; }
        [ForeignKey("ContainerOwner")]
        public int OwnerID { get; set; }
        [ForeignKey("ContainerType")]
        public int ContainerTypeID { get; set; }
        [ForeignKey("VirtualBlock")]
        public int? VirtualBlockID { get; set; }
        [ForeignKey("LocationStatus")]
        public int LocationStatusID { get; set; }
        [ForeignKey("LineOperator")]
        public int LineOperatorID { get; set; }
        [ForeignKey("FullStatus")]
        public int FullStatusID { get; set; }

        public ContainerSize ContainerSize { get; set; }
        public ContStatus ContainerStatus { get; set; }
        public ContainerOwner ContainerOwner { get; set; }
        public ContainerType ContainerType { get; set; }
        public VirtualBlock VirtualBlock { get; set; }
        public LocationStatus LocationStatus { get; set; }
        public LineOperator LineOperator { get; set; }
        public FullStatus FullStatus { get; set; }
    }
}
