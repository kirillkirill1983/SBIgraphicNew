﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SBIgraphic;

namespace SBIgraphic.Migrations
{
    [DbContext(typeof(ApplicattionContext))]
    [Migration("20220125080403_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("SBIgraphic.Model.Plavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NomerPlavki")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomerShtuki")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Plavka");
                });

            modelBuilder.Entity("SBIgraphic.Model.ZamerHirina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PlavkaId")
                        .HasColumnType("int");

                    b.Property<double>("Shirina")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PlavkaId");

                    b.ToTable("ZamerHirinas");
                });

            modelBuilder.Entity("SBIgraphic.Model.ZamerTolchina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("PlavkaId")
                        .HasColumnType("int");

                    b.Property<double>("Tolshina")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PlavkaId");

                    b.ToTable("ZamerTolchinas");
                });

            modelBuilder.Entity("SBIgraphic.Model.ZamerHirina", b =>
                {
                    b.HasOne("SBIgraphic.Model.Plavka", "Plavka")
                        .WithMany("ZamerHirinas")
                        .HasForeignKey("PlavkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plavka");
                });

            modelBuilder.Entity("SBIgraphic.Model.ZamerTolchina", b =>
                {
                    b.HasOne("SBIgraphic.Model.Plavka", "Plavka")
                        .WithMany("ZamerTolchinas")
                        .HasForeignKey("PlavkaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Plavka");
                });

            modelBuilder.Entity("SBIgraphic.Model.Plavka", b =>
                {
                    b.Navigation("ZamerHirinas");

                    b.Navigation("ZamerTolchinas");
                });
#pragma warning restore 612, 618
        }
    }
}