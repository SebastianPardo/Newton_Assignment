using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewtonServices.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Code", "DateUpdated", "Name" },
                values: new object[,]
                {
                    { new Guid("38c82dc7-0baa-4981-b620-841fc7d4076a"), "ACT", null, "Action" },
                    { new Guid("690ddf28-b89d-4d73-845a-61a3fe97d231"), "SPO", null, "Sport" },
                    { new Guid("ac0a73cb-b745-4889-86db-8bd5a0712cd3"), "SHT", null, "Shooter" },
                    { new Guid("b7fd6b7d-b307-404a-94ac-c908359adbe0"), "ADV", null, "Adventure" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Code", "DateUpdated", "Name" },
                values: new object[,]
                {
                    { new Guid("0c85b57f-643c-4176-9e1b-48a17d03ea7e"), "PS", null, "PlayStation" },
                    { new Guid("3c8ccba5-b0d7-45cd-8072-c5876f0593dc"), "PC", null, "PC" },
                    { new Guid("55bd7dd8-c9f1-4745-a7a6-c4509a82be67"), "XBX", null, "Xbox" }
                });

            migrationBuilder.InsertData(
                table: "VideoGames",
                columns: new[] { "Id", "DateUpdated", "GenreId", "PlatformId", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { new Guid("18e12425-b124-4e3d-b88c-8312c3b370be"), null, new Guid("b7fd6b7d-b307-404a-94ac-c908359adbe0"), new Guid("3c8ccba5-b0d7-45cd-8072-c5876f0593dc"), 69.99m, 10, "Game 3" },
                    { new Guid("3134f924-ca72-4a1e-a5bd-3f86e15fd937"), null, new Guid("690ddf28-b89d-4d73-845a-61a3fe97d231"), new Guid("0c85b57f-643c-4176-9e1b-48a17d03ea7e"), 59.99m, 10, "Game 1" },
                    { new Guid("8c80d238-8ab2-48b1-9cde-2a2e1a826731"), null, new Guid("b7fd6b7d-b307-404a-94ac-c908359adbe0"), new Guid("3c8ccba5-b0d7-45cd-8072-c5876f0593dc"), 69.99m, 10, "Game 5" },
                    { new Guid("a345f2da-75ed-4f30-9fd3-1cad0f7500c7"), null, new Guid("38c82dc7-0baa-4981-b620-841fc7d4076a"), new Guid("55bd7dd8-c9f1-4745-a7a6-c4509a82be67"), 49.99m, 10, "Game 2" },
                    { new Guid("f73166ab-47f1-47b9-8e15-a94f7b0ed216"), null, new Guid("690ddf28-b89d-4d73-845a-61a3fe97d231"), new Guid("0c85b57f-643c-4176-9e1b-48a17d03ea7e"), 69.99m, 10, "Game 4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("ac0a73cb-b745-4889-86db-8bd5a0712cd3"));

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: new Guid("18e12425-b124-4e3d-b88c-8312c3b370be"));

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: new Guid("3134f924-ca72-4a1e-a5bd-3f86e15fd937"));

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: new Guid("8c80d238-8ab2-48b1-9cde-2a2e1a826731"));

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: new Guid("a345f2da-75ed-4f30-9fd3-1cad0f7500c7"));

            migrationBuilder.DeleteData(
                table: "VideoGames",
                keyColumn: "Id",
                keyValue: new Guid("f73166ab-47f1-47b9-8e15-a94f7b0ed216"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("38c82dc7-0baa-4981-b620-841fc7d4076a"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("690ddf28-b89d-4d73-845a-61a3fe97d231"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("b7fd6b7d-b307-404a-94ac-c908359adbe0"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("0c85b57f-643c-4176-9e1b-48a17d03ea7e"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("3c8ccba5-b0d7-45cd-8072-c5876f0593dc"));

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: new Guid("55bd7dd8-c9f1-4745-a7a6-c4509a82be67"));
        }
    }
}
