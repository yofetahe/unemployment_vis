using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace our_project.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnemploymentStats",
                columns: table => new
                {
                    InstanceId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StateCode = table.Column<int>(nullable: false),
                    CountyCode = table.Column<int>(nullable: false),
                    County = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    Force = table.Column<int>(nullable: false),
                    Employed = table.Column<int>(nullable: false),
                    Unemployed = table.Column<int>(nullable: false),
                    UnemploymentRate = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnemploymentStats", x => x.InstanceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnemploymentStats");
        }
    }
}
