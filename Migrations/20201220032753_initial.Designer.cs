﻿// <auto-generated />
using System;
using EcomerceProject.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EcomerceProject.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20201220032753_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EcomerceProject.Entities.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            id = 1,
                            address = "binh thanh",
                            email = "toilahuy098@gmail.com",
                            name = "huy",
                            phone = "0933691822",
                            status = true,
                            userid = 1
                        },
                        new
                        {
                            id = 2,
                            address = "binh thanh",
                            email = "toilahuy098@gmail.com",
                            name = "huy",
                            phone = "0933691822",
                            status = true,
                            userid = 1
                        },
                        new
                        {
                            id = 3,
                            address = "binh thanh",
                            email = "toilahuy098@gmail.com",
                            name = "hoai",
                            phone = "0933691822",
                            status = true,
                            userid = 2
                        },
                        new
                        {
                            id = 4,
                            address = "binh thanh",
                            email = "toilahuy098@gmail.com",
                            name = "hoai",
                            phone = "0933691822",
                            status = true,
                            userid = 2
                        });
                });

            modelBuilder.Entity("EcomerceProject.Entities.OrderDetail", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("orderid")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<int>("productid")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("orderid");

                    b.HasIndex("productid");

                    b.ToTable("OrderDetail");

                    b.HasData(
                        new
                        {
                            id = 1,
                            orderid = 1,
                            price = 5000f,
                            productid = 1,
                            quantity = 2
                        });
                });

            modelBuilder.Entity("EcomerceProject.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("create_at")
                        .HasColumnType("datetime2");

                    b.Property<int>("finalprice")
                        .HasColumnType("int");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("saleprice")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<DateTime>("update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            id = 1,
                            create_at = new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(6033),
                            finalprice = 4600,
                            image = "image/p1.jpg",
                            name = "Nokia",
                            price = 5000,
                            saleprice = 400,
                            status = 1,
                            update_at = new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(6574)
                        },
                        new
                        {
                            id = 2,
                            create_at = new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(7136),
                            finalprice = 4600,
                            image = "image/p2.jpg",
                            name = "Samsung Galaxy",
                            price = 5000,
                            saleprice = 400,
                            status = 1,
                            update_at = new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(7148)
                        },
                        new
                        {
                            id = 3,
                            create_at = new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(7158),
                            finalprice = 4600,
                            image = "image/p3.jpg",
                            name = "Samsung Note",
                            price = 5000,
                            saleprice = 400,
                            status = 1,
                            update_at = new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(7159)
                        },
                        new
                        {
                            id = 4,
                            create_at = new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(7161),
                            finalprice = 4600,
                            image = "image/p4.jpg",
                            name = "Iphone",
                            price = 5000,
                            saleprice = 400,
                            status = 1,
                            update_at = new DateTime(2020, 12, 20, 10, 27, 52, 750, DateTimeKind.Local).AddTicks(7162)
                        });
                });

            modelBuilder.Entity("EcomerceProject.Entities.ShoppingCart", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("EcomerceProject.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("create_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("level")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<DateTime>("update_at")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            id = 1,
                            address = "binh thanh",
                            avatar = "image/p1.png",
                            create_at = new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(99),
                            email = "toilahuy098@gmail.com",
                            level = true,
                            name = "huy",
                            password = "123456",
                            phone = "0933691822",
                            status = true,
                            update_at = new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(8767)
                        },
                        new
                        {
                            id = 2,
                            address = "quan 3",
                            avatar = "image/p2.png",
                            create_at = new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9458),
                            email = "thaochi098@gmail.com",
                            level = false,
                            name = "chi",
                            password = "123456",
                            phone = "0933691822",
                            status = true,
                            update_at = new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9471)
                        },
                        new
                        {
                            id = 3,
                            address = "quan 3",
                            avatar = "image/p2.png",
                            create_at = new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9541),
                            email = "hoaixp@gmail.com",
                            level = false,
                            name = "hoai",
                            password = "123456",
                            phone = "0933691822",
                            status = true,
                            update_at = new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9543)
                        },
                        new
                        {
                            id = 4,
                            address = "quan 3",
                            avatar = "image/p2.png",
                            create_at = new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9545),
                            email = "lanttm@gmail.com",
                            level = false,
                            name = "lan",
                            password = "123456",
                            phone = "0933691822",
                            status = true,
                            update_at = new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9546)
                        },
                        new
                        {
                            id = 5,
                            address = "quan 3",
                            avatar = "image/p2.png",
                            create_at = new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9548),
                            email = "lanttm@gmail.com",
                            level = false,
                            name = "lan",
                            password = "123456",
                            phone = "0933691822",
                            status = true,
                            update_at = new DateTime(2020, 12, 20, 10, 27, 52, 746, DateTimeKind.Local).AddTicks(9549)
                        });
                });

            modelBuilder.Entity("EcomerceProject.Entities.Order", b =>
                {
                    b.HasOne("EcomerceProject.Entities.User", null)
                        .WithMany("Orders")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EcomerceProject.Entities.OrderDetail", b =>
                {
                    b.HasOne("EcomerceProject.Entities.Order", null)
                        .WithMany("orderDetails")
                        .HasForeignKey("orderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcomerceProject.Entities.Product", null)
                        .WithMany("orderDetails")
                        .HasForeignKey("productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
