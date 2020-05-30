using Microsoft.EntityFrameworkCore.Migrations;

namespace AwesomeColours.Repository.Migrations
{
    public partial class MyInitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IsAuthorised = table.Column<bool>(nullable: false),
                    IsValid = table.Column<bool>(nullable: false),
                    IsEnabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonColours",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    ColourId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonColours", x => new { x.PersonId, x.ColourId });
                    table.ForeignKey(
                        name: "FK_PersonColours_Colours_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonColours_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "Id", "IsEnabled", "Name" },
                values: new object[,]
                {
                    { 1, true, "Red" },
                    { 2, true, "Green" },
                    { 3, true, "Blue" }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "FirstName", "IsAuthorised", "IsEnabled", "IsValid", "LastName" },
                values: new object[,]
                {
                    { 1, "Willis", false, false, true, "Tibbs" },
                    { 2, "Sharon", false, false, false, "Halt" },
                    { 3, "Patrick", false, true, true, "Kerr" },
                    { 4, "Lilly", false, false, false, "Hale" },
                    { 5, "Joel", false, true, true, "Daly" },
                    { 6, "Imogen", false, true, false, "Kent" },
                    { 7, "George", false, true, true, "Edwards" },
                    { 8, "Gabriel", false, false, false, "Franics" },
                    { 9, "Courtney", false, true, true, "Arnold" },
                    { 10, "Brian", false, true, true, "Allen" },
                    { 11, "Bo", true, true, true, "Bob" }
                });

            migrationBuilder.InsertData(
                table: "PersonColours",
                columns: new[] { "PersonId", "ColourId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 10, 2, 0 },
                    { 10, 1, 0 },
                    { 9, 1, 0 },
                    { 8, 2, 0 },
                    { 7, 3, 0 },
                    { 7, 2, 0 },
                    { 6, 1, 0 },
                    { 5, 2, 0 },
                    { 4, 3, 0 },
                    { 4, 2, 0 },
                    { 4, 1, 0 },
                    { 3, 2, 0 },
                    { 2, 3, 0 },
                    { 2, 2, 0 },
                    { 2, 1, 0 },
                    { 1, 3, 0 },
                    { 1, 2, 0 },
                    { 10, 3, 0 },
                    { 11, 1, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonColours_ColourId",
                table: "PersonColours",
                column: "ColourId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonColours");

            migrationBuilder.DropTable(
                name: "Colours");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
