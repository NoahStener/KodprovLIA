﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoahStener_KodprovLIA.Data;

#nullable disable

namespace NoahStener_KodprovLIA.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240508133117_Initial Migration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("NoahStener_KodprovLIA.Models.Entities.Car", b =>
                {
                    b.Property<int>("CarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarID"));

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("RegNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("CarID");

                    b.HasIndex("RegNumber")
                        .IsUnique();

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            CarID = 1,
                            Model = "Volvo",
                            RegNumber = "ABC543"
                        },
                        new
                        {
                            CarID = 2,
                            Model = "Saab",
                            RegNumber = "BBB123"
                        },
                        new
                        {
                            CarID = 3,
                            Model = "Kia",
                            RegNumber = "CCC741"
                        },
                        new
                        {
                            CarID = 4,
                            Model = "Volvo",
                            RegNumber = "DAB092"
                        });
                });

            modelBuilder.Entity("NoahStener_KodprovLIA.Models.Entities.CarIssue", b =>
                {
                    b.Property<int>("CarIssueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarIssueID"));

                    b.Property<int>("CarID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("IssueReported")
                        .HasColumnType("datetime2");

                    b.HasKey("CarIssueID");

                    b.HasIndex("CarID");

                    b.ToTable("CarIssues");

                    b.HasData(
                        new
                        {
                            CarIssueID = 200,
                            CarID = 1,
                            Description = "Motorfel",
                            IssueReported = new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CarIssueID = 201,
                            CarID = 3,
                            Description = "Fel med växellåda",
                            IssueReported = new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CarIssueID = 202,
                            CarID = 2,
                            Description = "Punktering",
                            IssueReported = new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            CarIssueID = 203,
                            CarID = 1,
                            Description = "Elektronik problem",
                            IssueReported = new DateTime(2024, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("NoahStener_KodprovLIA.Models.Entities.CarIssue", b =>
                {
                    b.HasOne("NoahStener_KodprovLIA.Models.Entities.Car", "Car")
                        .WithMany("CarIssues")
                        .HasForeignKey("CarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("NoahStener_KodprovLIA.Models.Entities.Car", b =>
                {
                    b.Navigation("CarIssues");
                });
#pragma warning restore 612, 618
        }
    }
}
