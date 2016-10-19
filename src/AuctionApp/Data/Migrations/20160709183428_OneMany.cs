using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AuctionApp.Data.Migrations
{
    public partial class OneMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemsAuction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    MinimumBid = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NumberOfBid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsAuction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BidsAuctionItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BidAmount = table.Column<decimal>(nullable: false),
                    BidName = table.Column<string>(nullable: true),
                    ItemAuctionId = table.Column<int>(nullable: true),
                    ItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BidsAuctionItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BidsAuctionItem_ItemsAuction_ItemAuctionId",
                        column: x => x.ItemAuctionId,
                        principalTable: "ItemsAuction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BidsAuctionItem_ItemAuctionId",
                table: "BidsAuctionItem",
                column: "ItemAuctionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BidsAuctionItem");

            migrationBuilder.DropTable(
                name: "ItemsAuction");
        }
    }
}
