﻿// <auto-generated />
using FW_Assessment2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FW_Assessment2.Migrations
{
    [DbContext(typeof(TrashBagsContext))]
    partial class TrashBagsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FW_Assessment2.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandId");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            BrandId = 1,
                            Name = "Killeen"
                        },
                        new
                        {
                            BrandId = 2,
                            Name = "Tesco"
                        });
                });

            modelBuilder.Entity("FW_Assessment2.Models.TrashBag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<bool>("Compostable")
                        .HasColumnType("bit");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("TrashBags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            Compostable = false,
                            Volume = 50
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 1,
                            Compostable = false,
                            Volume = 30
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 1,
                            Compostable = true,
                            Volume = 10
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 1,
                            Compostable = false,
                            Volume = 100
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 1,
                            Compostable = true,
                            Volume = 1000
                        });
                });

            modelBuilder.Entity("FW_Assessment2.Models.TrashBag", b =>
                {
                    b.HasOne("FW_Assessment2.Models.Brand", "Brand")
                        .WithMany("TrashBags")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}