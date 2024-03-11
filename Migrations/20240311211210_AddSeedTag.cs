using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GardenGuardian.Migrations
{
    public partial class AddSeedTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "SeedTags");
        }
    }
}
