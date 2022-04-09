using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MigrationApp_s20540_Kolokwium.Migrations
{
    public partial class AddedDataToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "IdArtist", "NickName" },
                values: new object[,]
                {
                    { 1, "Banksy" },
                    { 2, "Kat123" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "IdEvent", "EndDate", "Name", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2001, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified), "Bal Maturalny", new DateTime(2000, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2019, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified), "Wesele", new DateTime(2019, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Organisers",
                columns: new[] { "IdOrganiser", "OrganiserName" },
                values: new object[,]
                {
                    { 1, "Fimra123" },
                    { 2, "123Firma" }
                });

            migrationBuilder.InsertData(
                table: "Artist_Events",
                columns: new[] { "IdArtist", "IdEvent", "PerformanceDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2000, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2000, 12, 31, 5, 10, 20, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Event_Organisers",
                columns: new[] { "IdEvent", "IdOrganiser" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Artist_Events",
                keyColumns: new[] { "IdArtist", "IdEvent" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Artist_Events",
                keyColumns: new[] { "IdArtist", "IdEvent" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Event_Organisers",
                keyColumns: new[] { "IdEvent", "IdOrganiser" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Event_Organisers",
                keyColumns: new[] { "IdEvent", "IdOrganiser" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "IdArtist",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "IdArtist",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "IdEvent",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "IdEvent",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Organisers",
                keyColumn: "IdOrganiser",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Organisers",
                keyColumn: "IdOrganiser",
                keyValue: 2);
        }
    }
}
