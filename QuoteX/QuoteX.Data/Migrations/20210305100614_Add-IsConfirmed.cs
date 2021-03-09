using Microsoft.EntityFrameworkCore.Migrations;

namespace QuoteX.Data.Migrations
{
    public partial class AddIsConfirmed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAcceptedByAdmin",
                table: "Quotes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAcceptedByAdmin",
                table: "Quotes");
        }
    }
}
