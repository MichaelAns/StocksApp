﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Stocks.EntityFramework.Date;

#nullable disable

namespace Stocks.EntityFramework.Migrations
{
    [DbContext(typeof(StocksDbContext))]
    [Migration("20220530191209_adduser")]
    partial class adduser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<DateOnly>("CbdDate")
                        .HasColumnType("date");

                    b.Property<double>("CbdPrice")
                        .HasColumnType("double precision");

                    b.Property<int>("MarketStockId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MarketStockId");

                    b.ToTable("CostByDate");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.Dividend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("DivAmount")
                        .HasColumnType("double precision");

                    b.Property<double>("DivProfit")
                        .HasColumnType("double precision");

                    b.Property<DateOnly>("DivTime")
                        .HasColumnType("date");

                    b.Property<int>("StockId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("Dividend");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.Issuer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("IssuerCost")
                        .HasColumnType("double precision");

                    b.Property<string>("IssuerCountry")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IssuerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("IssuerProfit")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Issuer");
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

            modelBuilder.Entity("Stocks.EntityFramework.Models.MarketStock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MarketId")
                        .HasColumnType("integer");

                    b.Property<string>("MsCurrency")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("StockId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MarketId");

                    b.HasIndex("StockId");

                    b.ToTable("MarketStock");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IssuerId")
                        .HasColumnType("integer");

                    b.Property<string>("StockName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IssuerId");

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
                    b.HasOne("Stocks.EntityFramework.Models.MarketStock", "MarketStock")
                        .WithMany("CostsByDates")
                        .HasForeignKey("MarketStockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MarketStock");
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

            modelBuilder.Entity("Stocks.EntityFramework.Models.MarketStock", b =>
                {
                    b.HasOne("Stocks.EntityFramework.Models.Market", "Market")
                        .WithMany("MarketsStocks")
                        .HasForeignKey("MarketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Stocks.EntityFramework.Models.Stock", "Stock")
                        .WithMany("MarketsStocks")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Market");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.Stock", b =>
                {
                    b.HasOne("Stocks.EntityFramework.Models.Issuer", "Issuer")
                        .WithMany("Stocks")
                        .HasForeignKey("IssuerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Issuer");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.Issuer", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.Market", b =>
                {
                    b.Navigation("MarketsStocks");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.MarketStock", b =>
                {
                    b.Navigation("CostsByDates");
                });

            modelBuilder.Entity("Stocks.EntityFramework.Models.Stock", b =>
                {
                    b.Navigation("Dividends");

                    b.Navigation("MarketsStocks");
                });
#pragma warning restore 612, 618
        }
    }
}
