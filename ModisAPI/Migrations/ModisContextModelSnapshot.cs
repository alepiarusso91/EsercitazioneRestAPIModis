﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModisAPI.Models;

namespace ModisAPI.Migrations
{
    [DbContext(typeof(ModisContext))]
    partial class ModisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ModisAPI.Models.Corso", b =>
                {
                    b.Property<int>("CorsoId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataInizio");

                    b.Property<int>("DurataInOre");

                    b.Property<int>("Livello");

                    b.Property<string>("Nome");

                    b.Property<int>("NumeroMassimoPerPartecipanti");

                    b.HasKey("CorsoId");

                    b.ToTable("Corsi");
                });

            modelBuilder.Entity("ModisAPI.Models.Studente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cognome");

                    b.Property<string>("Indirizzo");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Studenti");
                });

            modelBuilder.Entity("ModisAPI.Models.StudenteCorso", b =>
                {
                    b.Property<int>("StudenteId");

                    b.Property<int>("CorsoId");

                    b.HasKey("StudenteId", "CorsoId");

                    b.HasIndex("CorsoId");

                    b.ToTable("StudenteCorsi");
                });

            modelBuilder.Entity("ModisAPI.Models.StudenteCorso", b =>
                {
                    b.HasOne("ModisAPI.Models.Corso", "Corso")
                        .WithMany("StudenteCorsi")
                        .HasForeignKey("CorsoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ModisAPI.Models.Studente", "Studente")
                        .WithMany("StudenteCorsi")
                        .HasForeignKey("StudenteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
