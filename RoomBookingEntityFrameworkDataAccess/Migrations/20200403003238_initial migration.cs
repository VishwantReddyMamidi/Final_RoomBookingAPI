using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RoomBookingEntityFrameworkDataAccess.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingsTable",
                columns: table => new
                {
                    BookingID = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    RoomNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingsTable", x => x.BookingID);
                });

            migrationBuilder.CreateTable(
                name: "PaymentTranscation",
                columns: table => new
                {
                    PaymentTranscationID = table.Column<Guid>(nullable: false),
                    BookingID = table.Column<Guid>(nullable: false),
                    AmountPaid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentTranscation", x => x.PaymentTranscationID);
                    table.ForeignKey(
                        name: "FK_PaymentTranscation_BookingsTable_BookingID",
                        column: x => x.BookingID,
                        principalTable: "BookingsTable",
                        principalColumn: "BookingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTranscation_BookingID",
                table: "PaymentTranscation",
                column: "BookingID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentTranscation");

            migrationBuilder.DropTable(
                name: "BookingsTable");
        }
    }
}
