﻿// <auto-generated />
using System;
using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLibrary.Migrations
{
    [DbContext(typeof(DebtContext))]
    partial class DebtContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Core.Entities.ExternalDebtModel", b =>
                {
                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<double>("Debt")
                        .HasColumnType("float");

                    b.HasKey("Time");

                    b.ToTable("ExternalDebtsAPI");
                });

            modelBuilder.Entity("Core.Entities.ExternalIncreaseModel", b =>
                {
                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<double>("Debt")
                        .HasColumnType("float");

                    b.Property<double>("Increase")
                        .HasColumnType("float");

                    b.HasKey("Time");

                    b.ToTable("ExternalDebtsInfo");
                });

            modelBuilder.Entity("Core.Entities.InternalDebtModel", b =>
                {
                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<double>("Debt")
                        .HasColumnType("float");

                    b.HasKey("Time");

                    b.ToTable("InternalDebtsAPI");
                });

            modelBuilder.Entity("Core.Entities.InternalIncreaseModel", b =>
                {
                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<double>("Debt")
                        .HasColumnType("float");

                    b.Property<double>("Increase")
                        .HasColumnType("float");

                    b.HasKey("Time");

                    b.ToTable("InternalDebtsInfo");
                });
#pragma warning restore 612, 618
        }
    }
}