﻿// <auto-generated />
using System;
using Bill_api.Database.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NodaTime;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bill_api.Migrations
{
    [DbContext(typeof(BillContext))]
    partial class BillContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bill_api.Database.Models.Bill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float?>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<LocalDate?>("PayDate")
                        .HasColumnType("date");

                    b.Property<int>("ProviderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Bill_api.Database.Models.BillProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<LocalDate>("FirstPayment")
                        .HasColumnType("date");

                    b.Property<int>("PaymentDays")
                        .HasColumnType("integer");

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BillProviders");
                });

            modelBuilder.Entity("Bill_api.Database.Models.PayingPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PayingPersons");
                });

            modelBuilder.Entity("Bill_api.Database.Models.Bill", b =>
                {
                    b.HasOne("Bill_api.Database.Models.BillProvider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Provider");
                });
#pragma warning restore 612, 618
        }
    }
}
