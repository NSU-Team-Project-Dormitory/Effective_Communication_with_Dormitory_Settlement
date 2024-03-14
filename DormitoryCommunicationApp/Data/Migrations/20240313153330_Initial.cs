using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {



            migrationBuilder.CreateIndex(
                name: "IX_Dormitories_AddressID",
                table: "Dormitories",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Dormitories_Contactid",
                table: "Dormitories",
                column: "Contactid");

            migrationBuilder.CreateIndex(
                name: "IX_Floors_BuildingID",
                table: "Floors",
                column: "BuildingID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_FloorID",
                table: "Rooms",
                column: "FloorID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAccomodations_DormitoryID",
                table: "StudentAccomodations",
                column: "DormitoryID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAccomodations_RoomID",
                table: "StudentAccomodations",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressID",
                table: "Students",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_RoomID",
                table: "Students",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_StudentGroupID",
                table: "Students",
                column: "StudentGroupID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentAccomodations");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "StudentGroup");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropTable(
                name: "Dormitories");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
