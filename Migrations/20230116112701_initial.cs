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
                name: "Budgets",
                columns: table => new
                {
                    BudgetID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<bool>(type: "bit", nullable: false),
                    Week = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.BudgetID);
                });

            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    DayID = table.Column<int>(type: "int", nullable: false)
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
                    table.PrimaryKey("PK_Days", x => x.DayID);
                });

            migrationBuilder.CreateTable(
                name: "Measurements",
                columns: table => new
                {
                    MeasurementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feet = table.Column<bool>(type: "bit", nullable: false),
                    Meters = table.Column<bool>(type: "bit", nullable: false),
                    FeetOrMeters = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurements", x => x.MeasurementID);
                });

            migrationBuilder.CreateTable(
                name: "WorkPlaces",
                columns: table => new
                {
                    WorkPlaceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusicStudio = table.Column<bool>(type: "bit", nullable: false),
                    ArtStudio = table.Column<bool>(type: "bit", nullable: false),
                    PhotoStudio = table.Column<bool>(type: "bit", nullable: false),
                    DanceRehersalStudio = table.Column<bool>(type: "bit", nullable: false),
                    CeramicsStudio = table.Column<bool>(type: "bit", nullable: false),
                    PaintingWorkshop = table.Column<bool>(type: "bit", nullable: false),
                    OtherStudio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPlaces", x => x.WorkPlaceID);
                });

            migrationBuilder.CreateTable(
                name: "DatesAndTimes",
                columns: table => new
                {
                    DatesAndTimeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OpeningTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClosingTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DayID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatesAndTimes", x => x.DatesAndTimeID);
                    table.ForeignKey(
                        name: "FK_DatesAndTimes_Days_DayID",
                        column: x => x.DayID,
                        principalTable: "Days",
                        principalColumn: "DayID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adverts",
                columns: table => new
                {
                    AdvertID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: true),
                    Offering = table.Column<bool>(type: "bit", nullable: true),
                    Looking = table.Column<bool>(type: "bit", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMedia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkPlaceID = table.Column<int>(type: "int", nullable: false),
                    AmenityID = table.Column<int>(type: "int", nullable: false),
                    BudgetID = table.Column<int>(type: "int", nullable: false),
                    MeasurementID = table.Column<int>(type: "int", nullable: false),
                    DatesAndTimeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adverts", x => x.AdvertID);
                    table.ForeignKey(
                        name: "FK_Adverts_Amenities_AmenityID",
                        column: x => x.AmenityID,
                        principalTable: "Amenities",
                        principalColumn: "AmenityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_Budgets_BudgetID",
                        column: x => x.BudgetID,
                        principalTable: "Budgets",
                        principalColumn: "BudgetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_DatesAndTimes_DatesAndTimeID",
                        column: x => x.DatesAndTimeID,
                        principalTable: "DatesAndTimes",
                        principalColumn: "DatesAndTimeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_Measurements_MeasurementID",
                        column: x => x.MeasurementID,
                        principalTable: "Measurements",
                        principalColumn: "MeasurementID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adverts_WorkPlaces_WorkPlaceID",
                        column: x => x.WorkPlaceID,
                        principalTable: "WorkPlaces",
                        principalColumn: "WorkPlaceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_AmenityID",
                table: "Adverts",
                column: "AmenityID");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_BudgetID",
                table: "Adverts",
                column: "BudgetID");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_DatesAndTimeID",
                table: "Adverts",
                column: "DatesAndTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_MeasurementID",
                table: "Adverts",
                column: "MeasurementID");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_WorkPlaceID",
                table: "Adverts",
                column: "WorkPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_DatesAndTimes_DayID",
                table: "DatesAndTimes",
                column: "DayID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adverts");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "DatesAndTimes");

            migrationBuilder.DropTable(
                name: "Measurements");

            migrationBuilder.DropTable(
                name: "WorkPlaces");

            migrationBuilder.DropTable(
                name: "Days");
        }
    }
}
