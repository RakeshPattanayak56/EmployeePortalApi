﻿// <auto-generated />
using System;
using EmployeeLoginInfo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeLoginInfo.Migrations
{
    [DbContext(typeof(EmployeeDb2022Context))]
    [Migration("20220602141829_EmployeeDetail2022")]
    partial class EmployeeDetail2022
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StudentLoginInfo.Models.EmployeeDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("InDeskTimeIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("InDeskTimeOut")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Login")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Logout")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
