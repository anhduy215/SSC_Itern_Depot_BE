namespace DepotBackEnd.DTO.Container
{
    public class CreateContainerDTO
    {
        public string ContainerNumber { get; set; } = string.Empty;
        public string ISO { get; set; } = string.Empty;
        public float MaximumWeight { get; set; }
        public float TareWeight { get; set; }
        public DateTime DateOfManufacture { get; set; }
        public string? ContainerStatus { get; set; }
        public int SizeID { get; set; }
        public int OwnerID { get; set; }
        public int ContainerTypeID { get; set; }
        public int LineOperatorID { get; set; }
        public int FullStatusID { get; set; }
        //location và virtualblock auto bằng null để update sau
    }
}

