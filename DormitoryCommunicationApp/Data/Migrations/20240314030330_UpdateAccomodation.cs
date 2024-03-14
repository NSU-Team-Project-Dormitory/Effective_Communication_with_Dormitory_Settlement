using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAccomodation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dormitories_Address_AddressID",
                table: "Dormitories");

            migrationBuilder.DropForeignKey(
                name: "FK_Dormitories_Contact_Contactid",
                table: "Dormitories");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentGroup_StudentGroupID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "Contactid",
                table: "Dormitories",
                newName: "ContactID");

            migrationBuilder.RenameIndex(
                name: "IX_Dormitories_Contactid",
                table: "Dormitories",
                newName: "IX_Dormitories_ContactID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Contact",
                newName: "ID");

            migrationBuilder.AlterColumn<int>(
                name: "StudentGroupID",
                table: "Students",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Students",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Students",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "StudentAccomodations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "StudentAccomodations",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Rooms",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Rooms",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Floors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Floors",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "ContactID",
                table: "Dormitories",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "AddressID",
                table: "Dormitories",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Address",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Dormitories_Address_AddressID",
                table: "Dormitories",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dormitories_Contact_ContactID",
                table: "Dormitories",
                column: "ContactID",
                principalTable: "Contact",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentGroup_StudentGroupID",
                table: "Students",
                column: "StudentGroupID",
                principalTable: "StudentGroup",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dormitories_Address_AddressID",
                table: "Dormitories");

            migrationBuilder.DropForeignKey(
                name: "FK_Dormitories_Contact_ContactID",
                table: "Dormitories");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_StudentGroup_StudentGroupID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "StudentAccomodations");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "StudentAccomodations");

            migrationBuilder.RenameColumn(
                name: "ContactID",
                table: "Dormitories",
                newName: "Contactid");

            migrationBuilder.RenameIndex(
                name: "IX_Dormitories_ContactID",
                table: "Dormitories",
                newName: "IX_Dormitories_Contactid");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Contact",
                newName: "id");

            migrationBuilder.AlterColumn<int>(
                name: "StudentGroupID",
                table: "Students",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Students",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Rooms",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Capacity",
                table: "Rooms",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Floors",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Height",
                table: "Floors",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Contactid",
                table: "Dormitories",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressID",
                table: "Dormitories",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Street",
                table: "Address",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Region",
                table: "Address",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "Address",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Address",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Address",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Dormitories_Address_AddressID",
                table: "Dormitories",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dormitories_Contact_Contactid",
                table: "Dormitories",
                column: "Contactid",
                principalTable: "Contact",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_StudentGroup_StudentGroupID",
                table: "Students",
                column: "StudentGroupID",
                principalTable: "StudentGroup",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
