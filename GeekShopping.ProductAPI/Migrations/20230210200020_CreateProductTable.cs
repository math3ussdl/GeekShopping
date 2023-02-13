using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GeekShopping.ProductAPI.Migrations
{
  /// <inheritdoc />
  public partial class CreateProductTable : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "product",
          columns: table => new
          {
            id = table.Column<long>(type: "bigint", nullable: false)
                  .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
            name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
            price = table.Column<decimal>(type: "numeric", nullable: false),
            description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
            categoryname = table.Column<string>(name: "category_name", type: "character varying(50)", maxLength: 50, nullable: false),
            imageurl = table.Column<string>(name: "image_url", type: "character varying(300)", maxLength: 300, nullable: false),
            createdat = table.Column<DateTime>(name: "created_at", type: "timestamp with time zone", nullable: false),
            updatedat = table.Column<DateTime>(name: "updated_at", type: "timestamp with time zone", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_product", x => x.id);
          });
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "product");
    }
  }
}
