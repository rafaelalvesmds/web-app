﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApp.API.Context;

#nullable disable

namespace WebApp.API.Migrations
{
    [DbContext(typeof(WebAppContext))]
    [Migration("20231026234905_initial_load_expenseType_domain")]
    partial class initial_load_expenseType_domain
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApp.API.Repository.DataBase.expense", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("character varying(180)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("expenseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("expenseType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("includedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("id");

                    b.ToTable("expenses", "management");
                });

            modelBuilder.Entity("WebApp.API.Repository.DataBase.expenseType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.HasKey("id");

                    b.ToTable("expenseType", "domain");
                });

            modelBuilder.Entity("WebApp.API.Repository.DataBase.user", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int?>("cellphone")
                        .HasColumnType("integer");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("character varying(180)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<DateTime>("registrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("id");

                    b.ToTable("users", "auth");
                });
#pragma warning restore 612, 618
        }
    }
}