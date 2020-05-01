﻿// <auto-generated />
using CarControl.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarControl.Migrations
{
    [DbContext(typeof(CarControlContext))]
    partial class CarControlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CarControl.Models.Fabricante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<int>("Prioridade");

                    b.Property<string>("Site");

                    b.HasKey("Id");

                    b.ToTable("Fabricante");
                });

            modelBuilder.Entity("CarControl.Models.ModeloCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FabricanteId");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("FabricanteId");

                    b.ToTable("ModeloCar");
                });

            modelBuilder.Entity("CarControl.Models.ModeloCar", b =>
                {
                    b.HasOne("CarControl.Models.Fabricante", "Fabricante")
                        .WithMany("ModeloCar")
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
