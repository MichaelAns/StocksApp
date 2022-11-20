﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Stocks.EntityFramework.Date;

#nullable disable

namespace Stocks.EntityFramework.Migrations
{
    [DbContext(typeof(StocksDbContext))]
    partial class StocksDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Stocks.EntityFramework.Models.CostByDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Close")
                        .HasColumnType("double precision");

                    b.Property<int>("StockId")
                        .HasColumnType("integer");

                    b.Property<string>("StockSecID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TradeDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("CostByDate");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.Dividend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrencyID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Isin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RegistryCloseDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("StockId")
                        .HasColumnType("integer");

                    b.Property<string>("StockSecID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Value")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("Dividend");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.Market", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("MarketCoutry")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MarketName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Market");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrencyID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("MarketID")
                        .HasColumnType("integer");

                    b.Property<string>("SecID")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MarketID");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("UserIsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.CostByDate", b =>
                {
                    b.HasOne("Stocks.EntityFramework.Models.Stock", "Stock")
                        .WithMany("CostByDates")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.Dividend", b =>
                {
                    b.HasOne("Stocks.EntityFramework.Models.Stock", "Stock")
                        .WithMany("Dividends")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.Stock", b =>
                {
                    b.HasOne("Stocks.EntityFramework.Models.Market", "Market")
                        .WithMany("Stocks")
                        .HasForeignKey("MarketID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Market");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.Market", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.Stock", b =>
                {
                    b.Navigation("CostByDates");

                    b.Navigation("Dividends");
                });
#pragma warning restore 612, 618
        }
    }
}
