namespace DepotBackEnd.DTO
{
    public class CreateContainerDTO
    {
        public string ISO { get; set; }
        public decimal MaximumWeight { get; set; }
        public decimal TareWeight { get; set; }
        public DateTime? DateOfManufacture { get; set; }
        public int SizeID { get; set; }
        public int ContainerStatusID { get; set; }
        public int OwnerID { get; set; }
        public int ContainerTypeID { get; set; }
        public int? VirtualBlockID { get; set; }
        public int LocationStatusID { get; set; }
        public int LineOperatorID { get; set; }
        public int FullStatusID { get; set; }
    }
}

