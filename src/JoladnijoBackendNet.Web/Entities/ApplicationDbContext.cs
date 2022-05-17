namespace JoladnijoBackendNet.Web.Entities;

public class ApplicationDbContext : DbContext
{
   public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
   {

   }

   protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
   {
      base.ConfigureConventions(configurationBuilder);

      configurationBuilder.Properties<string>().HaveMaxLength(255);
   }

   protected override void OnModelCreating(ModelBuilder modelBuilder)
   {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfigurationsFromAssembly(typeof(Program).Assembly);
   }

   public DbSet<Organization> Organizations { get; set; }
   public DbSet<AidCenter> AidCenters { get; set; }
   public DbSet<Contact> Contacts { get; set; }
   public DbSet<AssetCategory> AssetCategories { get; set; }
   public DbSet<AssetType> AssetTypes { get; set; }
   public DbSet<AssetRequest> AssetRequests { get; set; }
   public DbSet<FeedItem> FeedItems { get; set; }

}
