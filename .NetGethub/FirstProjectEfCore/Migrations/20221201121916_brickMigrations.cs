using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstProjectEfCore.Migrations
{
    /// <inheritdoc />
    public partial class brickMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients");

            migrationBuilder.RenameTable(
                name: "DishIngredients",
                newName: "DishIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_DishIngredients_DishId",
                table: "DishIngredient",
                newName: "IX_DishIngredient_DishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishIngredient",
                table: "DishIngredient",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Bricks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Color = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: true),
                    Width = table.Column<int>(type: "int", nullable: true),
                    IsDualSided = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bricks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrickTag",
                columns: table => new
                {
                    BricksId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrickTag", x => new { x.BricksId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_BrickTag_Bricks_BricksId",
                        column: x => x.BricksId,
                        principalTable: "Bricks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrickTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "brickAvailabilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    BrickId = table.Column<int>(type: "int", nullable: false),
                    AvailableAmount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brickAvailabilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_brickAvailabilities_Bricks_BrickId",
                        column: x => x.BrickId,
                        principalTable: "Bricks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_brickAvailabilities_Vendors_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_brickAvailabilities_BrickId",
                table: "brickAvailabilities",
                column: "BrickId");

            migrationBuilder.CreateIndex(
                name: "IX_brickAvailabilities_VendorId",
                table: "brickAvailabilities",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_BrickTag_TagsId",
                table: "BrickTag",
                column: "TagsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredient_Dishes_DishId",
                table: "DishIngredient",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DishIngredient_Dishes_DishId",
                table: "DishIngredient");

            migrationBuilder.DropTable(
                name: "brickAvailabilities");

            migrationBuilder.DropTable(
                name: "BrickTag");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "Bricks");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DishIngredient",
                table: "DishIngredient");

            migrationBuilder.RenameTable(
                name: "DishIngredient",
                newName: "DishIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_DishIngredient_DishId",
                table: "DishIngredients",
                newName: "IX_DishIngredients_DishId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishIngredients",
                table: "DishIngredients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DishIngredients_Dishes_DishId",
                table: "DishIngredients",
                column: "DishId",
                principalTable: "Dishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
