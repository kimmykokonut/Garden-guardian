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
                name: "Seeds",
                columns: table => new
                {
                    SeedId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Information = table.Column<string>(type: "text", nullable: true),
                    PlantingDates = table.Column<string>(type: "text", nullable: true),
                    DaysToGerminate = table.Column<string>(type: "text", nullable: true),
                    DepthToSow = table.Column<string>(type: "text", nullable: true),
                    SeedSpacing = table.Column<string>(type: "text", nullable: true),
                    RowSpacing = table.Column<string>(type: "text", nullable: true),
                    DaysToHarvest = table.Column<int>(type: "integer", nullable: false),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    DatePlanted = table.Column<string>(type: "text", nullable: true),
                    Results = table.Column<string>(type: "text", nullable: true),
                    Yield = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seeds", x => x.SeedId);
                });

            migrationBuilder.InsertData(
                table: "Seeds",
                columns: new[] { "SeedId", "DatePlanted", "DaysToGerminate", "DaysToHarvest", "DepthToSow", "Information", "Name", "PhotoUrl", "PlantingDates", "Quantity", "Results", "RowSpacing", "SeedSpacing", "Status", "Type", "Yield" },
                values: new object[] { 1, "2-14-2024", "5-10", 45, "1/4-1/2 in", "The Hakurei Turnip (a.k.a Tokyo Turnip) variety is usually stark white and has an unmatched crispness and tender sweetness. This turnip is commonly eaten raw which has led to it being given the nickname of 'Salad Turnip'.", "Hakurei Turnip", "https://cdn.mos.cms.futurecdn.net/HMr9ceyW7Sc2kuz2S3dNF5.jpg", "spring, fall, winter", 10, "n/a", "12-24in", "2 in", "planted", "vegetable", 5 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seeds");
        }
    }
}
