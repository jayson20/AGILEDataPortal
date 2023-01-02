using Microsoft.EntityFrameworkCore.Migrations;

namespace AGILEDataPortal.Migrations
{
    public partial class AddIsPassWordChangedToApplicationUserModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPassWordChanged",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPassWordChanged",
                table: "AspNetUsers");
        }
    }
}
