using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LingonberryStudio.Migrations
{
    /// <inheritdoc />
    public partial class Inputfieldsnewupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ArtistName",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Budget",
                table: "Adverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Days",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Facilities",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OfferingLooking",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Adverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SocialMedia",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkspaceDescription",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "ArtistName",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Facilities",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "OfferingLooking",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "SocialMedia",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "WorkspaceDescription",
                table: "Adverts");
        }
    }
}
