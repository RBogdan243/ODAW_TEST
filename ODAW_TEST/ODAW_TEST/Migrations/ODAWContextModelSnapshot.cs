﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ODAW_TEST.Data;

#nullable disable

namespace ODAW_TEST.Migrations
{
    [DbContext(typeof(ODAWContext))]
    partial class ODAWContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ODAW_TEST.Models.Materie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Materii");
                });

            modelBuilder.Entity("ODAW_TEST.Models.Profesor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salariu")
                        .HasColumnType("float");

                    b.Property<string>("Tip_Profesor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Profesori");
                });

            modelBuilder.Entity("ODAW_TEST.Models.ProfesorMaterie", b =>
                {
                    b.Property<Guid>("ProfesorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MaterieId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProfesorId", "MaterieId");

                    b.HasIndex("MaterieId");

                    b.ToTable("ProfesorMaterie");
                });

            modelBuilder.Entity("ODAW_TEST.Models.ProfesorMaterie", b =>
                {
                    b.HasOne("ODAW_TEST.Models.Materie", "materie")
                        .WithMany("ProfesorMaterie")
                        .HasForeignKey("MaterieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ODAW_TEST.Models.Profesor", "prof")
                        .WithMany("ProfesorMaterie")
                        .HasForeignKey("ProfesorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("materie");

                    b.Navigation("prof");
                });

            modelBuilder.Entity("ODAW_TEST.Models.Materie", b =>
                {
                    b.Navigation("ProfesorMaterie");
                });

            modelBuilder.Entity("ODAW_TEST.Models.Profesor", b =>
                {
                    b.Navigation("ProfesorMaterie");
                });
#pragma warning restore 612, 618
        }
    }
}
