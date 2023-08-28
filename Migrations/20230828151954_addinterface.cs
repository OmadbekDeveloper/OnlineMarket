using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineMarket.Migrations
{
    /// <inheritdoc />
    public partial class addinterface : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingInfo_Orders_OrderId",
                table: "ShippingInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingInfo",
                table: "ShippingInfo");

            migrationBuilder.RenameTable(
                name: "ShippingInfo",
                newName: "ShippingInfos");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingInfo_OrderId",
                table: "ShippingInfos",
                newName: "IX_ShippingInfos_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingInfos",
                table: "ShippingInfos",
                column: "ShippingInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingInfos_Orders_OrderId",
                table: "ShippingInfos",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingInfos_Orders_OrderId",
                table: "ShippingInfos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingInfos",
                table: "ShippingInfos");

            migrationBuilder.RenameTable(
                name: "ShippingInfos",
                newName: "ShippingInfo");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingInfos_OrderId",
                table: "ShippingInfo",
                newName: "IX_ShippingInfo_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingInfo",
                table: "ShippingInfo",
                column: "ShippingInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingInfo_Orders_OrderId",
                table: "ShippingInfo",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
