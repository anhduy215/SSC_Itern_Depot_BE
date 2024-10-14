namespace DepotBackEnd.DTO.Eir
{
    public class EirDTO
    {
        public int EirNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? TaxCode { get; set; }
        public string ContainerNumber { get; set; } = string.Empty;
        public string LineOperator { get; set; } = string.Empty;
        public string VehicleTypeName { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public DateTime? Deadline { get; set; }
        public string EirType { get; set; } = string.Empty;
        public string? Approvements { get; set; }
        public int? UserID { get; set; }
    }
}
