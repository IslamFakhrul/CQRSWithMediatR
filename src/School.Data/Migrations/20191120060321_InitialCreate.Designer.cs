﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using School.Data;

namespace School.Data.Migrations
{
    [DbContext(typeof(SchoolDbContext))]
    [Migration("20191120060321_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("School.Data.Entities.School", b =>
                {
                    b.Property<int>("RefId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SchoolAddress")
                        .IsRequired();

                    b.Property<string>("SchoolCode")
                        .IsRequired();

                    b.Property<string>("SchoolName")
                        .IsRequired();

                    b.Property<string>("SchoolPhoneNumber");

                    b.Property<string>("SchoolSector")
                        .IsRequired();

                    b.Property<string>("SchoolType")
                        .IsRequired();

                    b.Property<string>("SchoolUrl");

                    b.HasKey("RefId");

                    b.ToTable("Schools");
                });
#pragma warning restore 612, 618
        }
    }
}