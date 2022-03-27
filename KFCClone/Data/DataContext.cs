
using KFCClone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KFCClone.Data
{
    //public partial class DataContext : IdentityDbContext<User, IdentityRole<int>, int>
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddOn> AddOns { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderProduct> OrderProducts { get; set; } = null!;
        public virtual DbSet<OrderProductAddOn> OrderProductAddOns { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductAddOn> ProductAddOns { get; set; } = null!;
        public virtual DbSet<Promotion> Promotions { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddOn>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsDrink).HasColumnName("is_drink");

                entity.Property(e => e.IsUpsize).HasColumnName("is_upsize");

                entity.Property(e => e.Name)
                    .HasMaxLength(90)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(90)
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityName)
                    .HasMaxLength(90)
                    .HasColumnName("city_name");

                entity.Property(e => e.StateId).HasColumnName("state_id");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_City.state_id");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(90)
                    .HasColumnName("country_name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderTotal).HasColumnName("order_total");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders.user_id");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProducts.order_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProducts.product_id");
            });

            modelBuilder.Entity<OrderProductAddOn>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddOnId).HasColumnName("add_on_id");

                entity.Property(e => e.AddOnQuantity).HasColumnName("add_on_quantity");

                entity.Property(e => e.OrderProductId).HasColumnName("order_product_id");

                entity.HasOne(d => d.AddOn)
                    .WithMany(p => p.OrderProductAddOns)
                    .HasForeignKey(d => d.AddOnId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProductAddOns.add_on_id");

                entity.HasOne(d => d.OrderProduct)
                    .WithMany(p => p.OrderProductAddOns)
                    .HasForeignKey(d => d.OrderProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderProductAddOns.order_product_id");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CatergoryId).HasColumnName("catergory_id");

                entity.Property(e => e.DrinkCount).HasColumnName("drink_count");

                entity.Property(e => e.IsMeal).HasColumnName("is_meal");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(90)
                    .HasColumnName("product_description");

                entity.Property(e => e.ProductImage)
                    .HasMaxLength(90)
                    .HasColumnName("product_image");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(90)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductPrice).HasColumnName("product_price");

                entity.HasOne(d => d.Catergory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatergoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products.catergory_id");
            });

            modelBuilder.Entity<ProductAddOn>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddOnId).HasColumnName("add_on_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.AddOn)
                    .WithMany(p => p.ProductAddOns)
                    .HasForeignKey(d => d.AddOnId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductAddOns.add_on_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductAddOns)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductAddOns.product_id");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Image)
                    .HasMaxLength(90)
                    .HasColumnName("image");

                entity.Property(e => e.NextId).HasColumnName("next_id");

                entity.Property(e => e.PreviousId).HasColumnName("previous_id");

                entity.Property(e => e.Url)
                    .HasMaxLength(90)
                    .HasColumnName("url");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("State");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.StateName)
                    .HasMaxLength(90)
                    .HasColumnName("state_name");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_State.country_id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(60)
                    .HasColumnName("city");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(60)
                    .HasColumnName("contact_number");

                entity.Property(e => e.Country)
                    .HasMaxLength(60)
                    .HasColumnName("country");

                entity.Property(e => e.Email)
                    .HasMaxLength(90)
                    .HasColumnName("email");

                entity.Property(e => e.IsGuestUser).HasColumnName("is_guest_user");

                entity.Property(e => e.Name)
                    .HasMaxLength(90)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("password")
                    .IsFixedLength();

                entity.Property(e => e.State)
                    .HasMaxLength(60)
                    .HasColumnName("state");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
