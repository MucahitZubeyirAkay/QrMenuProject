﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QrMenu.Data;

#nullable disable

namespace QrMenu.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QrMenu.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("StateId")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("QrMenu.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("char(5)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("smalldatetime");

                    b.Property<byte>("StateId")
                        .HasColumnType("tinyint");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("WebAdress")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("QrMenu.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<byte>("StateId")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("QrMenu.Models.State", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("QrMenu.Models.Category", b =>
                {
                    b.HasOne("QrMenu.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("QrMenu.Models.Company", b =>
                {
                    b.HasOne("QrMenu.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("QrMenu.Models.Food", b =>
                {
                    b.HasOne("QrMenu.Models.State", "State")
                        .WithMany()
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });
#pragma warning restore 612, 618
        }
    }
}
