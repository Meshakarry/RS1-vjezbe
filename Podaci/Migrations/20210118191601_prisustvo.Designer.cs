﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Podaci;

namespace Podaci.Migrations
{
    [DbContext(typeof(mojDbContext))]
    [Migration("20210118191601_prisustvo")]
    partial class prisustvo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Podaci.EntityModels.Fakultet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("fakultets");
                });

            modelBuilder.Entity("Podaci.EntityModels.Ocjena", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ocjena")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ocjenas");
                });

            modelBuilder.Entity("Podaci.EntityModels.Opstina", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("opstinas");
                });

            modelBuilder.Entity("Podaci.EntityModels.Predmet", b =>
                {
                    b.Property<int>("predmetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("predmetID");

                    b.ToTable("predmets");
                });

            modelBuilder.Entity("Podaci.EntityModels.PredmetOcjena", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("datum_polaganja")
                        .HasColumnType("datetime2");

                    b.Property<int>("ocjenaID")
                        .HasColumnType("int");

                    b.Property<int>("predmetID")
                        .HasColumnType("int");

                    b.Property<int>("studentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ocjenaID");

                    b.HasIndex("predmetID");

                    b.HasIndex("studentID");

                    b.ToTable("predmetOcjenas");
                });

            modelBuilder.Entity("Podaci.EntityModels.PrisustvoNaNastavi", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("datum_prisustva")
                        .HasColumnType("datetime2");

                    b.Property<int>("predmetID")
                        .HasColumnType("int");

                    b.Property<int>("studentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("predmetID");

                    b.HasIndex("studentID");

                    b.ToTable("prisustvoNaNastavis");
                });

            modelBuilder.Entity("Podaci.EntityModels.Student", b =>
                {
                    b.Property<int>("studentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Br_Ind")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("fakultetID")
                        .HasColumnType("int");

                    b.Property<int>("opstinaID")
                        .HasColumnType("int");

                    b.HasKey("studentID");

                    b.HasIndex("fakultetID");

                    b.HasIndex("opstinaID");

                    b.ToTable("students");
                });

            modelBuilder.Entity("Podaci.EntityModels.PredmetOcjena", b =>
                {
                    b.HasOne("Podaci.EntityModels.Ocjena", "ocjena")
                        .WithMany()
                        .HasForeignKey("ocjenaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Podaci.EntityModels.Predmet", "predmet")
                        .WithMany()
                        .HasForeignKey("predmetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Podaci.EntityModels.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Podaci.EntityModels.PrisustvoNaNastavi", b =>
                {
                    b.HasOne("Podaci.EntityModels.Predmet", "predmet")
                        .WithMany()
                        .HasForeignKey("predmetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Podaci.EntityModels.Student", "student")
                        .WithMany()
                        .HasForeignKey("studentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Podaci.EntityModels.Student", b =>
                {
                    b.HasOne("Podaci.EntityModels.Fakultet", "Fakultet")
                        .WithMany()
                        .HasForeignKey("fakultetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Podaci.EntityModels.Opstina", "Opstina")
                        .WithMany()
                        .HasForeignKey("opstinaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
