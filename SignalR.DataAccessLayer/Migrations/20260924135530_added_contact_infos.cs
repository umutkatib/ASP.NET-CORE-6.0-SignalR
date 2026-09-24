using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalR.DataAccessLayer.Migrations
{
    public partial class added_contact_infos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hours");

            migrationBuilder.AddColumn<string>(
                name: "ContactOpenDays",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactOpenDescription",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactOpenHours",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContactTitle",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactOpenDays",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactOpenDescription",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactOpenHours",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "ContactTitle",
                table: "Contacts");

            migrationBuilder.CreateTable(
                name: "Hours",
                columns: table => new
                {
                    HourID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HourDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HourDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HourTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hours", x => x.HourID);
                });
        }
    }
}
