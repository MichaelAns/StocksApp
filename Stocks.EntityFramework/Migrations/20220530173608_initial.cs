using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Stocks.EntityFramework.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issuer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IssuerName = table.Column<string>(type: "text", nullable: false),
                    IssuerCost = table.Column<double>(type: "double precision", nullable: false),
                    IssuerProfit = table.Column<double>(type: "double precision", nullable: false),
                    IssuerCountry = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issuer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MarketName = table.Column<string>(type: "text", nullable: false),
                    MarketCoutry = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StockName = table.Column<string>(type: "text", nullable: false),
                    IssuerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Issuer_IssuerId",
                        column: x => x.IssuerId,
                        principalTable: "Issuer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dividend",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DivTime = table.Column<DateOnly>(type: "date", nullable: false),
                    DivAmount = table.Column<double>(type: "double precision", nullable: false),
                    DivProfit = table.Column<double>(type: "double precision", nullable: false),
                    StockId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dividend", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dividend_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketStock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StockId = table.Column<int>(type: "integer", nullable: false),
                    MarketId = table.Column<int>(type: "integer", nullable: false),
                    MsCurrency = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketStock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketStock_Market_MarketId",
                        column: x => x.MarketId,
                        principalTable: "Market",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarketStock_Stock_StockId",
                        column: x => x.StockId,
                        principalTable: "Stock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CostByDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CbdDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CbdPrice = table.Column<double>(type: "double precision", nullable: false),
                    MarketStockId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostByDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CostByDate_MarketStock_MarketStockId",
                        column: x => x.MarketStockId,
                        principalTable: "MarketStock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CostByDate_MarketStockId",
                table: "CostByDate",
                column: "MarketStockId");

            migrationBuilder.CreateIndex(
                name: "IX_Dividend_StockId",
                table: "Dividend",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketStock_MarketId",
                table: "MarketStock",
                column: "MarketId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketStock_StockId",
                table: "MarketStock",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_IssuerId",
                table: "Stock",
                column: "IssuerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostByDate");

            migrationBuilder.DropTable(
                name: "Dividend");

            migrationBuilder.DropTable(
                name: "MarketStock");

            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Issuer");
        }
    }
}
