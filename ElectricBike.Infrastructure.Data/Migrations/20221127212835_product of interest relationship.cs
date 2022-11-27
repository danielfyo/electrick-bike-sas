using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectricBike.Infrastructure.Data.Migrations
{
    public partial class productofinterestrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ProductOfInterests_PurchaseIntentionId",
                table: "ProductOfInterests",
                column: "PurchaseIntentionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOfInterests_PurchaseIntentions_PurchaseIntentionId",
                table: "ProductOfInterests",
                column: "PurchaseIntentionId",
                principalTable: "PurchaseIntentions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductOfInterests_PurchaseIntentions_PurchaseIntentionId",
                table: "ProductOfInterests");

            migrationBuilder.DropIndex(
                name: "IX_ProductOfInterests_PurchaseIntentionId",
                table: "ProductOfInterests");
        }
    }
}
