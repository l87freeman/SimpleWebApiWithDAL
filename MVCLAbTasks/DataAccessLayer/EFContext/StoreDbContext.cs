using System.Data.Entity;
using DataAccessLayer.Entities;

namespace DataAccessLayer.EFContext
{
    public class StoreDbContext:DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PlatformType> PlatformTypes { get; set; }

        static StoreDbContext()
        {
            Database.SetInitializer(new StoreDbInitializer());
        }

        public StoreDbContext(string connectionString) : base(connectionString)
        {
            //Configuration.ProxyCreationEnabled = false;
            //this.Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>()
                .HasKey(p => p.Key)
                .HasMany(p => p.Genres)
                .WithMany(p => p.Games)
                .Map(ctx =>
                {
                    ctx.MapLeftKey("GameRefKey");
                    ctx.MapRightKey("GenreRefName");
                    ctx.ToTable("GameGenre");
                });

            modelBuilder.Entity<Game>()
                .HasMany(p => p.PlatformTypes)
                .WithMany(p => p.Games)
                .Map(ctx =>
                {
                    ctx.MapLeftKey("GameRefKey");
                    ctx.MapRightKey("PlatformTypeRefType");
                    ctx.ToTable("GamePlatformType");
                });

            modelBuilder.Entity<Game>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Genre>()
                .HasKey(p=>p.Name)
                .HasOptional(p => p.SubGenre)
                .WithMany()
                .HasForeignKey(p=>p.GenreParentName);

            modelBuilder.Entity<Comment>()
                .HasRequired(p=>p.Game)
                .WithMany(p=>p.Comments)
                .HasForeignKey(p=>p.GameKey)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Comment>()
                .HasOptional(p => p.ParentComment)
                .WithMany()
                .HasForeignKey(p => p.ParentCommentId);

            modelBuilder.Entity<PlatformType>()
                .HasKey(p => p.Type);

            SaveChanges();
            base.OnModelCreating(modelBuilder);
        }
    }

    
}
