using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GeekShopping.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_name", "created_at", "description", "image_url", "name", "price", "updated_at" },
                values: new object[,]
                {
                    { 1L, "Hobby", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carta rara que paralisou leilao!", "https://s2.glbimg.com/qnz29OQJebXxDQo-slkyH68WWBA=/0x0:444x643/984x0/smart/filters:strip_icc()/i.s3.glbimg.com/v1/AUTH_bc8228b6673f488aa253bbcb03c80ec5/internal_photos/bs/2021/A/e/dyDPEFST6Ezs8CqBTnQg/dragao.jpg", "Carta Yu-Gi-Oh Rara", 22000m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2L, "Escolar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Caneta azul, azul canetaaa...", "https://img.kalunga.com.br/fotosdeprodutos/176072z_2.jpg", "Caneta esferográfica azul", 2m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3L, "Escolar", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aproveite essa volta às aulas com estilo!", "https://m.media-amazon.com/images/I/51Z8ZM4sj8L._AC_SX679_.jpg", "Caderno Tilibra Azul", 6.5m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: 3L);
        }
    }
}
