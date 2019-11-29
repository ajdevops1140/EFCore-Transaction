using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore_Transaction.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    _Date = table.Column<string>(nullable: true),
                    _Description = table.Column<string>(nullable: true),
                    _Debit = table.Column<string>(nullable: true),
                    _Credit = table.Column<string>(nullable: true),
                    _Category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactions", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transactions");
        }
    }
}
