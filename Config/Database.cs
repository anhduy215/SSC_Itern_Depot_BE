using Microsoft.EntityFrameworkCore;
using Entity;
public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options) { }

    public DbSet<FullStatus> FullStatuses { get; set; }
    public DbSet<ContainerSize> ContainerSizes { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }
    public DbSet<ContainerType> ContainerTypes { get; set; }
    public DbSet<ContainerOwner> ContainerOwners { get; set; }
    public DbSet<Ship> Ships { get; set; }
    public DbSet<Voyage> Voyages { get; set; }
    public DbSet<LocationStatus> LocationStatuses { get; set; }
    public DbSet<ContStatus> ContainerStatuses { get; set; }
    public DbSet<LineOperator> LineOperators { get; set; }
    public DbSet<Depot> Depots { get; set; }
    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<VirtualBlock> VirtualBlocks { get; set; }
    public DbSet<ContainerBlock> ContainerBlocks { get; set; }
    public DbSet<Command> Commands { get; set; }
    public DbSet<Container> Containers { get; set; }
    public DbSet<LifeCycle> LifeCycles { get; set; }
    public DbSet<PositionContainer> PositionContainers { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<IOManagement> IOManagements { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<FullStatus>().ToTable("FullStatus");
        modelBuilder.Entity<ContainerSize>().ToTable("ContainerSize");
        modelBuilder.Entity<VehicleType>().ToTable("VehicleType");
        modelBuilder.Entity<ContainerType>().ToTable("ContainerType");
        modelBuilder.Entity<ContainerOwner>().ToTable("ContainerOwner");
        modelBuilder.Entity<Ship>().ToTable("Ship");
        modelBuilder.Entity<Voyage>().ToTable("Voyage");
        modelBuilder.Entity<LocationStatus>().ToTable("LocationStatus");
        modelBuilder.Entity<ContStatus>().ToTable("ContainerStatus");
        modelBuilder.Entity<LineOperator>().ToTable("LineOperator");
        modelBuilder.Entity<Depot>().ToTable("Depot");
        modelBuilder.Entity<UserAccount>().ToTable("UserAccount");
        modelBuilder.Entity<VirtualBlock>().ToTable("VirtualBlock");
        modelBuilder.Entity<ContainerBlock>().ToTable("ContainerBlock");
        modelBuilder.Entity<Command>().ToTable("Command");
        modelBuilder.Entity<Container>().ToTable("Container");
        modelBuilder.Entity<LifeCycle>().ToTable("LifeCycle");
        modelBuilder.Entity<PositionContainer>().ToTable("PositionContainer");
        modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
        modelBuilder.Entity<IOManagement>().ToTable("IOManagement");
    }
}
