using Microsoft.EntityFrameworkCore;

namespace ImageVideoManager.Data
{
    public class AlbumDbContext : DbContext
    {
        public AlbumDbContext()
        {
        }

        public AlbumDbContext(DbContextOptions<AlbumDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Get ConnectionString from appsettings.json
            IConfigurationRoot config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Media> Medias { get; set; }
        public virtual DbSet<BaseTag> Tags { get; set; }
        public virtual DbSet<MediaTag> MediaTags { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediaTag>()
                        .HasKey(mt => new { mt.MediaID, mt.TagID });
        }
    }
}