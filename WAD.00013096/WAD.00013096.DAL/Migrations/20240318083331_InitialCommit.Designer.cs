﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WAD._00013096.Data;

#nullable disable

namespace WAD._00013096.DAL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240318083331_InitialCommit")]
    partial class InitialCommit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WAD._00013096.Models.Person", b =>
            {
                b.Property<int>("PersonId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("PhoneNumber")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("EmailAddress")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("PersonId");

                b.ToTable("Companies");
            });

            modelBuilder.Entity("WAD._00013096.Models.Estate", b =>
            {
                b.Property<int>("EstateId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EstateId"));

                b.Property<int>("PersonId")
                    .HasColumnType("int");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Price")
                    .IsRequired()
                    .HasColumnType("int");

                b.Property<DateTime>("PostedDate")
                    .HasColumnType("datetime2");

                b.HasKey("EstateId");

                b.HasIndex("PersonId");

                b.ToTable("Estate");
            });

            modelBuilder.Entity("WAD._00013096.Models.Estate", b =>
            {
                b.HasOne("WAD._00013096.Models.Person", "Person")
                    .WithMany("Estates")
                    .HasForeignKey("PersonId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Person");
            });

            modelBuilder.Entity("WAD._00013096.Models.Person", b =>
            {
                b.Navigation("Estates");
            });
        }
    }
}
