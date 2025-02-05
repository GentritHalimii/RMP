﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RMP.Host.Database;

#nullable disable

namespace RMP.Host.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241130201927_UniversityEntity")]
    partial class UniversityEntity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("RMP.Host.Entities.UniversityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("CoursesNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("EstablishedYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProfilePhotoPath")
                        .HasColumnType("TEXT");

                    b.Property<int>("StaffNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentsNumber")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Universities");
                });
#pragma warning restore 612, 618
        }
    }
}
