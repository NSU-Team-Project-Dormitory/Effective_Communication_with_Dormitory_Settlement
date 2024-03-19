using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Somemodifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dormitories_Address_AddressID",
                table: "Dormitories");

            migrationBuilder.DropForeignKey(
                name: "FK_Floors_Dormitories_DormitoryId",
                table: "Floors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Address_AddressID",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameColumn(
                name: "DormitoryId",
                table: "Floors",
                newName: "DormitoryID");

            migrationBuilder.RenameIndex(
                name: "IX_Floors_DormitoryId",
                table: "Floors",
                newName: "IX_Floors_DormitoryID");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dormitories_Addresses_AddressID",
                table: "Dormitories",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Floors_Dormitories_DormitoryID",
                table: "Floors",
                column: "DormitoryID",
                principalTable: "Dormitories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Addresses_AddressID",
                table: "Students",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dormitories_Addresses_AddressID",
                table: "Dormitories");

            migrationBuilder.DropForeignKey(
                name: "FK_Floors_Dormitories_DormitoryID",
                table: "Floors");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Addresses_AddressID",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "DormitoryID",
                table: "Floors",
                newName: "DormitoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Floors_DormitoryID",
                table: "Floors",
                newName: "IX_Floors_DormitoryId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dormitories_Address_AddressID",
                table: "Dormitories",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Floors_Dormitories_DormitoryId",
                table: "Floors",
                column: "DormitoryId",
                principalTable: "Dormitories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Address_AddressID",
                table: "Students",
                column: "AddressID",
                principalTable: "Address",
                principalColumn: "ID");
        }
    }
}
