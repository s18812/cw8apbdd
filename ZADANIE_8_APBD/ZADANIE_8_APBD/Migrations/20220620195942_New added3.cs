using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZADANIE_8_APBD.Migrations
{
    public partial class Newadded3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[] { 3, "j@k.com", "Franek", "Kowalski" });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[] { 4, "k@s.com", "Bronek", "Walecki" });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdDoctor", "Date", "DueDate", "IdPatient", "IdPrescription" },
                values: new object[] { 3, new DateTime(2022, 6, 20, 21, 59, 41, 941, DateTimeKind.Local).AddTicks(3293), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0 });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdDoctor", "Date", "DueDate", "IdPatient", "IdPrescription" },
                values: new object[] { 4, new DateTime(2022, 6, 20, 21, 59, 41, 943, DateTimeKind.Local).AddTicks(1503), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescription",
                keyColumn: "IdDoctor",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctor",
                keyColumn: "IdDoctor",
                keyValue: 4);
        }
    }
}
