using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LingonberryStudio.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Adverts",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "ArtistName",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Days",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Facilities",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Adverts");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Adverts",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "SocialMedia",
                table: "Adverts",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Adverts",
                newName: "MeasurementID");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Adverts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "MeasurementID",
                table: "Adverts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AdvertId",
                table: "Adverts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AmenityID",
                table: "Adverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DatesAndTimeID",
                table: "Adverts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adverts",
                table: "Adverts",
                column: "AdvertId");

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    AmenityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parking = table.Column<bool>(type: "bit", nullable: false),
                    AirCon = table.Column<bool>(type: "bit", nullable: false),
                    Kitchen = table.Column<bool>(type: "bit", nullable: false),
                    NaturalLight = table.Column<bool>(type: "bit", nullable: false),
                    AcousticTreatment = table.Column<bool>(type: "bit", nullable: false),
                    RunningWater = table.Column<bool>(type: "bit", nullable: false),
                    Storage = table.Column<bool>(type: "bit", nullable: false),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.AmenityID);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monday = table.Column<bool>(type: "bit", nullable: false),
                    Tuesday = table.Column<bool>(type: "bit", nullable: false),
                    Wednesday = table.Column<bool>(type: "bit", nullable: false),
                    Thursday = table.Column<bool>(type: "bit", nullable: false),
                    Friday = table.Column<bool>(type: "bit", nullable: false),
                    Saturday = table.Column<bool>(type: "bit", nullable: false),
                    Sunday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.DayId);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    MeasurementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeetOrMeters = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.MeasurementId);
                });

            migrationBuilder.CreateTable(
                name: "DatesAndTimes",
                columns: table => new
                {
                    DatesAndTimeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpeningTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosingTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DayID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatesAndTimes", x => x.DatesAndTimeId);
                    table.ForeignKey(
                        name: "FK_DatesAndTimes_Days_DayID",
                        column: x => x.DayID,
                        principalTable: "Days",
                        principalColumn: "DayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_AmenityID",
                table: "Adverts",
                column: "AmenityID");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_DatesAndTimeID",
                table: "Adverts",
                column: "DatesAndTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_MeasurementID",
                table: "Adverts",
                column: "MeasurementID");

            migrationBuilder.CreateIndex(
                name: "IX_DatesAndTimes_DayID",
                table: "DatesAndTimes",
                column: "DayID");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Amenities_AmenityID",
                table: "Adverts",
                column: "AmenityID",
                principalTable: "Amenities",
                principalColumn: "AmenityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_DatesAndTimes_DatesAndTimeID",
                table: "Adverts",
                column: "DatesAndTimeID",
                principalTable: "DatesAndTimes",
                principalColumn: "DatesAndTimeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Measurements_MeasurementID",
                table: "Adverts",
                column: "MeasurementID",
                principalTable: "Measurements",
                principalColumn: "MeasurementId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Amenities_AmenityID",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_DatesAndTimes_DatesAndTimeID",
                table: "Adverts");

            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Measurements_MeasurementID",
                table: "Adverts");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "DatesAndTimes");

            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "Days");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Adverts",
                table: "Adverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_AmenityID",
                table: "Adverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_DatesAndTimeID",
                table: "Adverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_MeasurementID",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "AdvertId",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "AmenityID",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "DatesAndTimeID",
                table: "Adverts");

            migrationBuilder.RenameColumn(
                name: "MeasurementID",
                table: "Adverts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Adverts",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Adverts",
                newName: "SocialMedia");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Adverts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Adverts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Adverts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

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
                name: "Name",
                table: "Adverts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Adverts",
                table: "Adverts",
                column: "Id");
        }
    }
}
