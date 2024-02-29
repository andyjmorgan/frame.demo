using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Frame.Demo.Stack.DBContext.Migrations
{
    /// <inheritdoc />
    public partial class databasecreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemperatureSamples",
                columns: table => new
                {
                    Location = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Temperature = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemperatureSamples");
        }
    }
}
