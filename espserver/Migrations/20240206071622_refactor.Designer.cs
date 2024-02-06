﻿// <auto-generated />
using System;
using Infrastructer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace espserver.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240206071622_refactor")]
    partial class refactor
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.DeviceChannelDef", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DeviceChannelCode")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<string>("DeviceChannelDesc")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("DeviceChannelNo")
                        .HasColumnType("integer");

                    b.Property<long>("DevicePortId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DevicePortId");

                    b.ToTable("DeviceChannelDef");
                });

            modelBuilder.Entity("Domain.Entities.DeviceDef", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DeviceAdressUrl")
                        .HasColumnType("text");

                    b.Property<string>("DeviceCode")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<string>("DeviceName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<long>("DeviceTypeId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DeviceTypeId");

                    b.ToTable("DeviceDef");
                });

            modelBuilder.Entity("Domain.Entities.DevicePortDef", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("DeviceId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("PortCode")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.Property<string>("PortDesc")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("PortNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.ToTable("DevicePortDef");
                });

            modelBuilder.Entity("Domain.Entities.DeviceTypeDef", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DeviceType")
                        .HasColumnType("integer");

                    b.Property<string>("DeviceTypeDesc")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DeviceTypeDef");
                });

            modelBuilder.Entity("Domain.Entities.DeviceChannelDef", b =>
                {
                    b.HasOne("Domain.Entities.DevicePortDef", "DevicePortDef")
                        .WithMany()
                        .HasForeignKey("DevicePortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DevicePortDef");
                });

            modelBuilder.Entity("Domain.Entities.DeviceDef", b =>
                {
                    b.HasOne("Domain.Entities.DeviceTypeDef", "DeviceTypeDef")
                        .WithMany()
                        .HasForeignKey("DeviceTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceTypeDef");
                });

            modelBuilder.Entity("Domain.Entities.DevicePortDef", b =>
                {
                    b.HasOne("Domain.Entities.DeviceDef", "DeviceDef")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DeviceDef");
                });
#pragma warning restore 612, 618
        }
    }
}
