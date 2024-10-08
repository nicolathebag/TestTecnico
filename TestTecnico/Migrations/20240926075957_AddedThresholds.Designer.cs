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
    [Migration("20240926075957_AddedThresholds")]
    partial class AddedThresholds
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("Threshold", b =>
                {
                    b.Property<int>("ThresholdId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThresholdId"));

                    b.Property<int>("Threshold1High")
                        .HasColumnType("int");

                    b.Property<int>("Threshold1Low")
                        .HasColumnType("int");

                    b.Property<int>("Threshold1Medium")
                        .HasColumnType("int");

                    b.Property<int>("Threshold2High")
                        .HasColumnType("int");

                    b.Property<int>("Threshold2Low")
                        .HasColumnType("int");

                    b.Property<int>("Threshold2Medium")
                        .HasColumnType("int");

                    b.Property<int>("Threshold3High")
                        .HasColumnType("int");

                    b.Property<int>("Threshold3Low")
                        .HasColumnType("int");

                    b.Property<int>("Threshold3Medium")
                        .HasColumnType("int");

                    b.Property<int>("Threshold4High")
                        .HasColumnType("int");

                    b.Property<int>("Threshold4Low")
                        .HasColumnType("int");

                    b.Property<int>("Threshold4Medium")
                        .HasColumnType("int");

                    b.HasKey("ThresholdId");

                    b.ToTable("Thresholds");
                });
#pragma warning restore 612, 618
        }
    }
}
