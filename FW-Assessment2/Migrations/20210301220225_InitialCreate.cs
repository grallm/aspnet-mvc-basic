using Microsoft.EntityFrameworkCore.Migrations;

namespace FW_Assessment2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "TrashBags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(nullable: false),
                    Volume = table.Column<int>(nullable: false),
                    Compostable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrashBags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrashBags_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Name" },
                values: new object[] { 1, "Killeen" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Name" },
                values: new object[] { 2, "Tesco" });

            migrationBuilder.InsertData(
                table: "TrashBags",
                columns: new[] { "Id", "BrandId", "Compostable", "Volume" },
                values: new object[,]
                {
                    { 1, 1, false, 50 },
                    { 2, 1, false, 30 },
                    { 3, 1, true, 10 },
                    { 4, 1, false, 100 },
                    { 5, 1, true, 1000 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrashBags_BrandId",
                table: "TrashBags",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrashBags");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
