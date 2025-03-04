﻿// <auto-generated />
using System;
using Axiom.Services.PersonAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Axiom.Services.PersonAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240705200112_AddPersonDetails")]
    partial class AddPersonDetails
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Axiom.Services.PersonAPI.Models.Person", b =>
                {
                    b.Property<long>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PersonId"));

                    b.Property<DateTimeOffset>("BirthDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ocuppation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PersonDetails", b =>
                {
                    b.Property<long>("PersonId")
                        .HasColumnType("bigint");

                    b.Property<string>("PreferredTechniques")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("PreferredTouchPressure")
                        .HasColumnType("tinyint");

                    b.Property<bool>("ReceivedProfessionalMassage")
                        .HasColumnType("bit");

                    b.Property<byte>("ServiceExpectations")
                        .HasColumnType("tinyint");

                    b.HasKey("PersonId");

                    b.ToTable("PersonDetails");
                });

            modelBuilder.Entity("PersonDetails", b =>
                {
                    b.HasOne("Axiom.Services.PersonAPI.Models.Person", "Person")
                        .WithOne("PersonDetails")
                        .HasForeignKey("PersonDetails", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Axiom.Services.PersonAPI.Models.Person", b =>
                {
                    b.Navigation("PersonDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
