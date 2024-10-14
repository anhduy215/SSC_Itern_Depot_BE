namespace DepotBackEnd.DTO.Container;
public class ContainerDTO
{
    public string ContainerNumber { get; set; } = string.Empty;
    public string ISO { get; set; } = string.Empty;
    public float MaximumWeight { get; set; }
    public float TareWeight { get; set; }
    public DateTime DateOfManufacture { get; set; }
    public string? ContainerStatus { get; set; }
    public int Size { get; set; }
    public string OwnerName { get; set; } = string.Empty;
    public string ContainerType { get; set; } = string.Empty;
    public string LocationStatus { get; set; } = string.Empty;
    public string? Position { get; set; }
}