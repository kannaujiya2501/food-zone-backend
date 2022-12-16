using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace food_zone.data
{
    public partial class foodzoneContext : DbContext
    {
        public foodzoneContext()
        {
        }

        public foodzoneContext(DbContextOptions<foodzoneContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Famousdish> Famousdish { get; set; }
        public virtual DbSet<Gallery> Gallery { get; set; }
        public virtual DbSet<Nonveg> Nonveg { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Veg> Veg { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=.;database=foodzone;TrustServerCertificate=true;Integrated Security = true;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Famousdish>(entity =>
            {
                entity.HasKey(e => e.FoodId);

                entity.ToTable("famousdish");

                entity.HasIndex(e => e.OrderId);

                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.FoodName)
                    .HasColumnName("food_name")
                    .HasMaxLength(30);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .HasMaxLength(50);

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Famousdish)
                    .HasForeignKey(d => d.OrderId);
            });

            modelBuilder.Entity<Gallery>(entity =>
            {
                entity.HasKey(e => e.FoodId);

                entity.ToTable("gallery");

                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.FoodName)
                    .HasColumnName("food_name")
                    .HasMaxLength(30);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Nonveg>(entity =>
            {
                entity.HasKey(e => e.FoodId);

                entity.ToTable("nonveg");

                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.FoodName)
                    .HasColumnName("food_name")
                    .HasMaxLength(30);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.OrderName)
                    .HasColumnName("order_name")
                    .HasMaxLength(30);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasMaxLength(50);

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Veg>(entity =>
            {
                entity.HasKey(e => e.FoodId);

                entity.ToTable("veg");

                entity.Property(e => e.FoodId).HasColumnName("food_id");

                entity.Property(e => e.FoodName)
                    .HasColumnName("food_name")
                    .HasMaxLength(30);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("image_url")
                    .HasMaxLength(50);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
