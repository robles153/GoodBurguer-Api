using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GoodBurguer.Migrations
{
    /// <inheritdoc />
    public partial class InserirProdutosPadrao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Ativo", "Nome", "Preco", "Tipo" },
                values: new object[,]
                {
                    { new Guid("a1f3c9b2-7d4e-4a1b-9c2e-1f7d8a2b3c4d"), true, "X Burger", 5.00m, 1 },
                    { new Guid("b2e4d6a8-9c1f-4d3a-b7e2-2c8f9a1b5d6e"), true, "X Egg", 4.50m, 1 },
                    { new Guid("c3d5e7f9-1a2b-4c3d-8e9f-3b7c6d5e4f2a"), true, "X Bacon", 7.00m, 1 },
                    { new Guid("d4e6f8a1-2b3c-4d5e-9f0a-4c8d7e6f5a3b"), true, "Batata frita", 2.00m, 2 },
                    { new Guid("e5f7a9b2-3c4d-5e6f-0a1b-5d9e8f7a6b4c"), true, "Refrigerante", 2.50m, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("a1f3c9b2-7d4e-4a1b-9c2e-1f7d8a2b3c4d"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("b2e4d6a8-9c1f-4d3a-b7e2-2c8f9a1b5d6e"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("c3d5e7f9-1a2b-4c3d-8e9f-3b7c6d5e4f2a"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("d4e6f8a1-2b3c-4d5e-9f0a-4c8d7e6f5a3b"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("e5f7a9b2-3c4d-5e6f-0a1b-5d9e8f7a6b4c"));
        }
    }
}
