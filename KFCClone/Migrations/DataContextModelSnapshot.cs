﻿// <auto-generated />
using System;
using KFCClone.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KFCClone.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("KFCClone.Models.AddOn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDrink")
                        .HasColumnType("bit")
                        .HasColumnName("is_drink");

                    b.Property<bool>("IsUpsize")
                        .HasColumnType("bit")
                        .HasColumnName("is_upsize");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)")
                        .HasColumnName("name");

                    b.Property<int>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.ToTable("AddOns");
                });

            modelBuilder.Entity("KFCClone.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)")
                        .HasColumnName("category_name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("KFCClone.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)")
                        .HasColumnName("city_name");

                    b.Property<int>("StateId")
                        .HasColumnType("int")
                        .HasColumnName("state_id");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("KFCClone.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)")
                        .HasColumnName("country_name");

                    b.HasKey("Id");

                    b.ToTable("Country", (string)null);
                });

            modelBuilder.Entity("KFCClone.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OrderTotal")
                        .HasColumnType("int")
                        .HasColumnName("order_total");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("payment_type");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("KFCClone.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int")
                        .HasColumnName("product_quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("KFCClone.Models.OrderProductAddOn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddOnId")
                        .HasColumnType("int")
                        .HasColumnName("add_on_id");

                    b.Property<int>("AddOnQuantity")
                        .HasColumnType("int")
                        .HasColumnName("add_on_quantity");

                    b.Property<int>("OrderProductId")
                        .HasColumnType("int")
                        .HasColumnName("order_product_id");

                    b.HasKey("Id");

                    b.HasIndex("AddOnId");

                    b.HasIndex("OrderProductId");

                    b.ToTable("OrderProductAddOns");
                });

            modelBuilder.Entity("KFCClone.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<int?>("DrinkCount")
                        .HasColumnType("int")
                        .HasColumnName("drink_count");

                    b.Property<bool?>("IsHomePageProduct")
                        .HasColumnType("bit")
                        .HasColumnName("is_home_page_product");

                    b.Property<bool>("IsMeal")
                        .HasColumnType("bit")
                        .HasColumnName("is_meal");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)")
                        .HasColumnName("product_description");

                    b.Property<string>("ProductImage")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)")
                        .HasColumnName("product_image");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)")
                        .HasColumnName("product_name");

                    b.Property<int>("ProductPrice")
                        .HasColumnType("int")
                        .HasColumnName("product_price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("KFCClone.Models.ProductAddOn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddOnId")
                        .HasColumnType("int")
                        .HasColumnName("add_on_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.HasKey("Id");

                    b.HasIndex("AddOnId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAddOns");
                });

            modelBuilder.Entity("KFCClone.Models.Promotion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)")
                        .HasColumnName("image");

                    b.Property<int?>("NextId")
                        .HasColumnType("int")
                        .HasColumnName("next_id");

                    b.Property<int?>("PreviousId")
                        .HasColumnType("int")
                        .HasColumnName("previous_id");

                    b.Property<string>("Url")
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)")
                        .HasColumnName("url");

                    b.HasKey("Id");

                    b.ToTable("Promotions");
                });

            modelBuilder.Entity("KFCClone.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("country_id");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)")
                        .HasColumnName("state_name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("State", (string)null);
                });

            modelBuilder.Entity("KFCClone.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("ContactNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("contact_number");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsGuestUser")
                        .HasColumnType("bit")
                        .HasColumnName("is_guest_user");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PersistInfo")
                        .HasColumnType("bit")
                        .HasColumnName("persist_info");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("StateId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KFCClone.Models.City", b =>
                {
                    b.HasOne("KFCClone.Models.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .IsRequired()
                        .HasConstraintName("FK_City.state_id");

                    b.Navigation("State");
                });

            modelBuilder.Entity("KFCClone.Models.Order", b =>
                {
                    b.HasOne("KFCClone.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .IsRequired()
                        .HasConstraintName("FK_Orders.user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KFCClone.Models.OrderProduct", b =>
                {
                    b.HasOne("KFCClone.Models.Order", "Order")
                        .WithMany("OrderProducts")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderProducts.order_id");

                    b.HasOne("KFCClone.Models.Product", "Product")
                        .WithMany("OrderProducts")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderProducts.product_id");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KFCClone.Models.OrderProductAddOn", b =>
                {
                    b.HasOne("KFCClone.Models.AddOn", "AddOn")
                        .WithMany("OrderProductAddOns")
                        .HasForeignKey("AddOnId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderProductAddOns.add_on_id");

                    b.HasOne("KFCClone.Models.OrderProduct", "OrderProduct")
                        .WithMany("OrderProductAddOns")
                        .HasForeignKey("OrderProductId")
                        .IsRequired()
                        .HasConstraintName("FK_OrderProductAddOns.order_product_id");

                    b.Navigation("AddOn");

                    b.Navigation("OrderProduct");
                });

            modelBuilder.Entity("KFCClone.Models.Product", b =>
                {
                    b.HasOne("KFCClone.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_Products.category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("KFCClone.Models.ProductAddOn", b =>
                {
                    b.HasOne("KFCClone.Models.AddOn", "AddOn")
                        .WithMany("ProductAddOns")
                        .HasForeignKey("AddOnId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductAddOns.add_on_id");

                    b.HasOne("KFCClone.Models.Product", "Product")
                        .WithMany("ProductAddOns")
                        .HasForeignKey("ProductId")
                        .IsRequired()
                        .HasConstraintName("FK_ProductAddOns.product_id");

                    b.Navigation("AddOn");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("KFCClone.Models.State", b =>
                {
                    b.HasOne("KFCClone.Models.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .IsRequired()
                        .HasConstraintName("FK_State.country_id");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("KFCClone.Models.User", b =>
                {
                    b.HasOne("KFCClone.Models.City", null)
                        .WithMany("Users")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KFCClone.Models.Country", null)
                        .WithMany("Users")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("KFCClone.Models.State", null)
                        .WithMany("Users")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("KFCClone.Models.AddOn", b =>
                {
                    b.Navigation("OrderProductAddOns");

                    b.Navigation("ProductAddOns");
                });

            modelBuilder.Entity("KFCClone.Models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("KFCClone.Models.City", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("KFCClone.Models.Country", b =>
                {
                    b.Navigation("States");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("KFCClone.Models.Order", b =>
                {
                    b.Navigation("OrderProducts");
                });

            modelBuilder.Entity("KFCClone.Models.OrderProduct", b =>
                {
                    b.Navigation("OrderProductAddOns");
                });

            modelBuilder.Entity("KFCClone.Models.Product", b =>
                {
                    b.Navigation("OrderProducts");

                    b.Navigation("ProductAddOns");
                });

            modelBuilder.Entity("KFCClone.Models.State", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("KFCClone.Models.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
