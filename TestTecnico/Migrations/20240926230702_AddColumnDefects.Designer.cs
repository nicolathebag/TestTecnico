﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TestTecnico.Migrations
{
    [DbContext(typeof(MeasuresContext))]
    [Migration("20240926230702_AddColumnDefects")]
    partial class AddColumnDefects
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Defect", b =>
                {
                    b.Property<int>("DefectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DefectId"));

                    b.Property<double>("Delta")
                        .HasColumnType("float");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MeasureId")
                        .HasColumnType("int");

                    b.Property<int>("p")
                        .HasColumnType("int");

                    b.HasKey("DefectId");

                    b.ToTable("Defects");
                });

            modelBuilder.Entity("Measure", b =>
                {
                    b.Property<int>("MeasureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeasureId"));

                    b.Property<double>("p1")
                        .HasColumnType("float");

                    b.Property<double>("p2")
                        .HasColumnType("float");

                    b.Property<double>("p3")
                        .HasColumnType("float");

                    b.Property<double>("p4")
                        .HasColumnType("float");

                    b.HasKey("MeasureId");

                    b.ToTable("Measures");
                });
#pragma warning restore 612, 618
        }
    }
}
