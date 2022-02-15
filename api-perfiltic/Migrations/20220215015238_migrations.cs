using Microsoft.EntityFrameworkCore.Migrations;

namespace api_perfiltic.Migrations
{
    public partial class migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pt_category",
                columns: table => new
                {
                    id_category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pt_category", x => x.id_category);
                });

            migrationBuilder.CreateTable(
                name: "pt_gallery",
                columns: table => new
                {
                    id_gallery = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    photo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    id_product = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pt_gallery", x => x.id_gallery);
                });

            migrationBuilder.CreateTable(
                name: "pt_products",
                columns: table => new
                {
                    id_product = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    weight = table.Column<double>(type: "float", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    id_subcategory = table.Column<int>(type: "int", nullable: false),
                    currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pt_products", x => x.id_product);
                });

            migrationBuilder.CreateTable(
                name: "pt_subcategory",
                columns: table => new
                {
                    id_subcategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    id_category = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pt_subcategory", x => x.id_subcategory);
                });

            migrationBuilder.CreateTable(
                name: "pt_users",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pt_users", x => x.id_user);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pt_category");

            migrationBuilder.DropTable(
                name: "pt_gallery");

            migrationBuilder.DropTable(
                name: "pt_products");

            migrationBuilder.DropTable(
                name: "pt_subcategory");

            migrationBuilder.DropTable(
                name: "pt_users");
        }
    }
}
