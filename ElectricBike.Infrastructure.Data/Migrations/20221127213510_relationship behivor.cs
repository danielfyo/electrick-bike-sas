using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectricBike.Infrastructure.Data.Migrations
{
    public partial class relationshipbehivor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicycles_Manufacturers_ManufacturerId",
                table: "Bicycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_EngineSuppliers_EngineSupplierId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Manufacturers_ManufacturerId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOfInterests_PurchaseIntentions_PurchaseIntentionId",
                table: "ProductOfInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseIntentions_Users_UserId",
                table: "PurchaseIntentions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Bicycles_Manufacturers_ManufacturerId",
                table: "Bicycles",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_EngineSuppliers_EngineSupplierId",
                table: "Motorcycles",
                column: "EngineSupplierId",
                principalTable: "EngineSuppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Manufacturers_ManufacturerId",
                table: "Motorcycles",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOfInterests_PurchaseIntentions_PurchaseIntentionId",
                table: "ProductOfInterests",
                column: "PurchaseIntentionId",
                principalTable: "PurchaseIntentions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseIntentions_Users_UserId",
                table: "PurchaseIntentions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bicycles_Manufacturers_ManufacturerId",
                table: "Bicycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_EngineSuppliers_EngineSupplierId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorcycles_Manufacturers_ManufacturerId",
                table: "Motorcycles");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductOfInterests_PurchaseIntentions_PurchaseIntentionId",
                table: "ProductOfInterests");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseIntentions_Users_UserId",
                table: "PurchaseIntentions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Bicycles_Manufacturers_ManufacturerId",
                table: "Bicycles",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_EngineSuppliers_EngineSupplierId",
                table: "Motorcycles",
                column: "EngineSupplierId",
                principalTable: "EngineSuppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorcycles_Manufacturers_ManufacturerId",
                table: "Motorcycles",
                column: "ManufacturerId",
                principalTable: "Manufacturers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductOfInterests_PurchaseIntentions_PurchaseIntentionId",
                table: "ProductOfInterests",
                column: "PurchaseIntentionId",
                principalTable: "PurchaseIntentions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseIntentions_Users_UserId",
                table: "PurchaseIntentions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Persons_PersonId",
                table: "Users",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
