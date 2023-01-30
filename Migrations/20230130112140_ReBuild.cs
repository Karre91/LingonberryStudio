using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LingonberryStudio.Migrations
{
    /// <inheritdoc />
    public partial class ReBuild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmenityTypes",
                columns: table => new
                {
                    AmenityID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parking = table.Column<bool>(type: "bit", nullable: false),
                    Shower = table.Column<bool>(type: "bit", nullable: false),
                    AirCondition = table.Column<bool>(type: "bit", nullable: false),
                    Kitchen = table.Column<bool>(type: "bit", nullable: false),
                    NaturalLight = table.Column<bool>(type: "bit", nullable: false),
                    AcousticTreatment = table.Column<bool>(type: "bit", nullable: false),
                    RunningWater = table.Column<bool>(type: "bit", nullable: false),
                    Storage = table.Column<bool>(type: "bit", nullable: false),
                    Toilet = table.Column<bool>(type: "bit", nullable: false),
                    CeramicOven = table.Column<bool>(type: "bit", nullable: false),
                    Other = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityTypes", x => x.AmenityID);
                });

            migrationBuilder.CreateTable(
                name: "TimeFrames",
                columns: table => new
                {
                    DatesAndTimeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpeningTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosingTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_TimeFrames", x => x.DatesAndTimeID);
                });

            migrationBuilder.CreateTable(
                name: "WorkPlace",
                columns: table => new
                {
                    WorkPlaceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Period = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pounds = table.Column<int>(type: "int", nullable: true),
                    MeasurementType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementNumber = table.Column<int>(type: "int", nullable: true),
                    AmenityID = table.Column<int>(type: "int", nullable: false),
                    TimeFrameID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPlace", x => x.WorkPlaceID);
                    table.ForeignKey(
                        name: "FK_WorkPlace_AmenityTypes_AmenityID",
                        column: x => x.AmenityID,
                        principalTable: "AmenityTypes",
                        principalColumn: "AmenityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkPlace_TimeFrames_TimeFrameID",
                        column: x => x.TimeFrameID,
                        principalTable: "TimeFrames",
                        principalColumn: "DatesAndTimeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Offering = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMedia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudioType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPlaceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Adverts_WorkPlace_WorkPlaceID",
                        column: x => x.WorkPlaceID,
                        principalTable: "WorkPlace",
                        principalColumn: "WorkPlaceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_WorkPlaceID",
                table: "Adverts",
                column: "WorkPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlace_AmenityID",
                table: "WorkPlace",
                column: "AmenityID");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlace_TimeFrameID",
                table: "WorkPlace",
                column: "TimeFrameID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "WorkPlace");

            migrationBuilder.DropTable(
                name: "AmenityTypes");

            migrationBuilder.DropTable(
                name: "TimeFrames");
        }
    }
}
