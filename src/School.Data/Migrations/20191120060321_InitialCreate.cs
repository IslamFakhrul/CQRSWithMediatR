using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Schools",
                columns: table => new
                {
                    RefId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SchoolCode = table.Column<string>(nullable: false),
                    SchoolName = table.Column<string>(nullable: false),
                    SchoolUrl = table.Column<string>(nullable: true),
                    SchoolAddress = table.Column<string>(nullable: false),
                    SchoolType = table.Column<string>(nullable: false),
                    SchoolPhoneNumber = table.Column<string>(nullable: true),
                    SchoolSector = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schools", x => x.RefId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Schools");
        }
    }
}
