using Microsoft.EntityFrameworkCore;
using Entity;
using DepotBackEnd.Entities;
public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options) { }

    public DbSet<FullStatus> FullStatuses { get; set; }
    public DbSet<ContainerSize> ContainerSizes { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }
    public DbSet<ContainerType> ContainerTypes { get; set; }
    public DbSet<Owner> ContainerOwners { get; set; }
    public DbSet<LocationStatus> LocationStatuses { get; set; }
    public DbSet<LineOperator> LineOperators { get; set; }
    public DbSet<Depot> Depots { get; set; }
    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<VirtualBlock> VirtualBlocks { get; set; }
    public DbSet<Container> Containers { get; set; }
    public DbSet<PositionContainer> PositionContainers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Eir> Eir { get; set; }
    public DbSet<Block> Blocks { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FullStatus>().ToTable("FullStatus");
        modelBuilder.Entity<ContainerSize>().ToTable("ContainerSize");
        modelBuilder.Entity<VehicleType>().ToTable("VehicleType");
        modelBuilder.Entity<ContainerType>().ToTable("ContainerType");
        modelBuilder.Entity<Owner>().ToTable("Owner");
        modelBuilder.Entity<LocationStatus>().ToTable("LocationStatus");
        modelBuilder.Entity<LineOperator>().ToTable("LineOperator");
        modelBuilder.Entity<Depot>().ToTable("Depot");
        modelBuilder.Entity<UserAccount>().ToTable("UserAccount");
        modelBuilder.Entity<VirtualBlock>().ToTable("VirtualBlock");
        modelBuilder.Entity<Container>().ToTable("Container");
        modelBuilder.Entity<PositionContainer>().ToTable("PositionContainer");
        modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
        modelBuilder.Entity<Eir>().ToTable("Eir");
        modelBuilder.Entity<Block>().ToTable("Block");
    }
}
