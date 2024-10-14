using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity
{
    public class Container
    {
        [Key]
        [Required] public string ContainerNumber { get; set; } = string.Empty;
        public string ISO { get; set; } = string.Empty;
        public float MaximumWeight { get; set; }
        public float TareWeight { get; set; }
        public DateTime? DateOfManufacture { get; set; }
        public string? ContainerStatus { get; set; }
        [ForeignKey("ContainerSize")]
        public int SizeID { get; set; }
        [ForeignKey("Owner")]
        public int OwnerID { get; set; }
        [ForeignKey("ContainerType")]
        public int ContainerTypeID { get; set; }
        [ForeignKey("VirtualBlock")]
        public int? VirtualBlockID { get; set; }
        [ForeignKey("LocationStatus")]
        public int? LocationStatusID { get; set; }
        [ForeignKey("LineOperator")]
        public int LineOperatorID { get; set; }
        [ForeignKey("FullStatus")]
        public int FullStatusID { get; set; }

        public ContainerSize? ContainerSize { get; set; }
        public Owner? Owner { get; set; }
        public ContainerType? ContainerType { get; set; }
        public VirtualBlock? VirtualBlock { get; set; }
        public LocationStatus? LocationStatus { get; set; }
        public LineOperator? LineOperator { get; set; }
        public FullStatus? FullStatus { get; set; }
    }
}
