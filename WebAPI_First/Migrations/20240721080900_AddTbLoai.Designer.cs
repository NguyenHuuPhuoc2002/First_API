﻿// <auto-generated />
using System;
using DemoEntityFrameworkCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WebAPI_First.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20240721080900_AddTbLoai")]
    partial class AddTbLoai
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI_First.Data.HangHoa", b =>
                {
                    b.Property<Guid>("MaHh")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DonGia")
                        .HasColumnType("float");

                    b.Property<byte>("GiamGia")
                        .HasColumnType("tinyint");

                    b.Property<int?>("MaLoai")
                        .HasColumnType("int");

                    b.Property<string>("Mota")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenHh")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaHh");

                    b.HasIndex("MaLoai");

                    b.ToTable("HangHoa");
                });

            modelBuilder.Entity("WebAPI_First.Data.Loai", b =>
                {
                    b.Property<int>("MaLoai")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLoai"));

                    b.Property<string>("TenLoai")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaLoai");

                    b.ToTable("Loai");
                });

            modelBuilder.Entity("WebAPI_First.Data.HangHoa", b =>
                {
                    b.HasOne("WebAPI_First.Data.Loai", "Loai")
                        .WithMany("HangHoas")
                        .HasForeignKey("MaLoai");

                    b.Navigation("Loai");
                });

            modelBuilder.Entity("WebAPI_First.Data.Loai", b =>
                {
                    b.Navigation("HangHoas");
                });
#pragma warning restore 612, 618
        }
    }
}
