using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GardenGuardian.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gardens",
                columns: table => new
                {
                    GardenId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(90)", maxLength: 90, nullable: false),
                    Size = table.Column<string>(type: "text", nullable: true),
                    GridQty = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gardens", x => x.GardenId);
                });

            migrationBuilder.CreateTable(
                name: "Seeds",
                columns: table => new
                {
                    SeedId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Information = table.Column<string>(type: "text", nullable: true),
                    PlantingDates = table.Column<string>(type: "text", nullable: true),
                    DaysToGerminate = table.Column<string>(type: "text", nullable: true),
                    DepthToSow = table.Column<string>(type: "text", nullable: true),
                    SeedSpacing = table.Column<string>(type: "text", nullable: true),
                    RowSpacing = table.Column<string>(type: "text", nullable: true),
                    DaysToHarvest = table.Column<int>(type: "integer", nullable: false),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DatePlanted = table.Column<string>(type: "text", nullable: true),
                    Results = table.Column<string>(type: "text", nullable: true),
                    Yield = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seeds", x => x.SeedId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameTag = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Grids",
                columns: table => new
                {
                    GridId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LocationCode = table.Column<string>(type: "text", nullable: false),
                    GardenId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grids", x => x.GridId);
                    table.ForeignKey(
                        name: "FK_Grids_Gardens_GardenId",
                        column: x => x.GardenId,
                        principalTable: "Gardens",
                        principalColumn: "GardenId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeedTags",
                columns: table => new
                {
                    SeedTagId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    SeedId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeedTags", x => x.SeedTagId);
                    table.ForeignKey(
                        name: "FK_SeedTags_Seeds_SeedId",
                        column: x => x.SeedId,
                        principalTable: "Seeds",
                        principalColumn: "SeedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeedTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GridSeeds",
                columns: table => new
                {
                    GridSeedId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GridId = table.Column<int>(type: "integer", nullable: false),
                    SeedId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GridSeeds", x => x.GridSeedId);
                    table.ForeignKey(
                        name: "FK_GridSeeds_Grids_GridId",
                        column: x => x.GridId,
                        principalTable: "Grids",
                        principalColumn: "GridId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GridSeeds_Seeds_SeedId",
                        column: x => x.SeedId,
                        principalTable: "Seeds",
                        principalColumn: "SeedId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Seeds",
                columns: new[] { "SeedId", "DatePlanted", "DaysToGerminate", "DaysToHarvest", "DepthToSow", "Information", "Name", "PhotoUrl", "PlantingDates", "Quantity", "Results", "RowSpacing", "SeedSpacing", "Status", "Type", "Yield" },
                values: new object[] { 1, "2-14-2024", "5-10", 45, "1/4-1/2 in", "The Hakurei Turnip (a.k.a Tokyo Turnip) variety is usually stark white and has an unmatched crispness and tender sweetness. This turnip is commonly eaten raw which has led to it being given the nickname of 'Salad Turnip'.", "Hakurei Turnip", "https://cdn.mos.cms.futurecdn.net/HMr9ceyW7Sc2kuz2S3dNF5.jpg", "spring, fall, winter", 10, "n/a", "12-24in", "2 in", "planted", "vegetable", 5 });

            migrationBuilder.CreateIndex(
                name: "IX_Grids_GardenId",
                table: "Grids",
                column: "GardenId");

            migrationBuilder.CreateIndex(
                name: "IX_GridSeeds_GridId",
                table: "GridSeeds",
                column: "GridId");

            migrationBuilder.CreateIndex(
                name: "IX_GridSeeds_SeedId",
                table: "GridSeeds",
                column: "SeedId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedTags_SeedId",
                table: "SeedTags",
                column: "SeedId");

            migrationBuilder.CreateIndex(
                name: "IX_SeedTags_TagId",
                table: "SeedTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GridSeeds");

            migrationBuilder.DropTable(
                name: "SeedTags");

            migrationBuilder.DropTable(
                name: "Grids");

            migrationBuilder.DropTable(
                name: "Seeds");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Gardens");
        }
    }
}
