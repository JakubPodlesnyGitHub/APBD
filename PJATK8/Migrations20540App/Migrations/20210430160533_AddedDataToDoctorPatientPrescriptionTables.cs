using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations20540App.Migrations
{
    public partial class AddedDataToDoctorPatientPrescriptionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "cos@cos.pl", "Jakub", "Komorowski" },
                    { 2, "cos123@dsa.pl", "Magda", "Romanowska" },
                    { 3, "kotek123@cdass.pl", "Marysia", "Wasilewska" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2000, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified), "Ala", "Chryniecka" },
                    { 2, new DateTime(1999, 5, 26, 5, 10, 20, 0, DateTimeKind.Unspecified), "Tomasz", "Tolak" },
                    { 3, new DateTime(2001, 11, 6, 5, 10, 20, 0, DateTimeKind.Unspecified), "Katarzyna", "Mykhalkiv" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 1, new DateTime(2019, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 2, new DateTime(2015, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified), new DateTime(2016, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified), 2, 2 });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[] { 3, new DateTime(2020, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified), new DateTime(2001, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified), 3, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 3);
        }
    }
}
