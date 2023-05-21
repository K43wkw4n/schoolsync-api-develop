﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolSync.DAL.EFCore;

#nullable disable

namespace SchoolSync.Migrations
{
    [DbContext(typeof(SchoolSyncDbContext))]
    partial class SchoolSyncDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SchoolSync.DAL.Entities.Division", b =>
                {
                    b.Property<string>("DivisionCode")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DivisionName")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("IsUsed")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.HasKey("DivisionCode");

                    b.ToTable("Division");
                });

            modelBuilder.Entity("SchoolSync.DAL.Entities.Position", b =>
                {
                    b.Property<string>("PositionCode")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("DivisionCode")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<string>("IsUsed")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.Property<string>("PositionName")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("varchar(1)");

                    b.HasKey("PositionCode");

                    b.HasIndex("DivisionCode");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("SchoolSync.DAL.Entities.Position", b =>
                {
                    b.HasOne("SchoolSync.DAL.Entities.Division", "Division")
                        .WithMany()
                        .HasForeignKey("DivisionCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");
                });
#pragma warning restore 612, 618
        }
    }
}
