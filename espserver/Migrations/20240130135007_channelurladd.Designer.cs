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
    [Migration("20240130135007_channelurladd")]
    partial class channelurladd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.CahannelAdressDef", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("ChannelAdressName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("ChannelAdrtessUrl")
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<long>("ChannelDefId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChannelDefId");

                    b.ToTable("CahannelAdressDef");
                });

            modelBuilder.Entity("Domain.Entities.EspPortDef", b =>
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

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("PortDesc")
                        .HasColumnType("text");

                    b.Property<string>("PortKey")
                        .HasColumnType("text");

                    b.Property<int>("PortNumber")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EspPortDef");
                });

            modelBuilder.Entity("Domain.Entities.ReleChannelDef", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("ChannelNo")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("EspPortDefId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("ReleChannelDesc")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("ReleChannelName")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("UpdatedUser")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EspPortDefId");

                    b.ToTable("ReleChannelDef");
                });

            modelBuilder.Entity("Domain.Entities.CahannelAdressDef", b =>
                {
                    b.HasOne("Domain.Entities.ReleChannelDef", "ChannelDef")
                        .WithMany()
                        .HasForeignKey("ChannelDefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChannelDef");
                });

            modelBuilder.Entity("Domain.Entities.ReleChannelDef", b =>
                {
                    b.HasOne("Domain.Entities.EspPortDef", "EspPortDef")
                        .WithMany()
                        .HasForeignKey("EspPortDefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EspPortDef");
                });
#pragma warning restore 612, 618
        }
    }
}
