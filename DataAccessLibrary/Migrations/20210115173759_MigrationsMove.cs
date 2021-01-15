using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLibrary.Migrations
{
    public partial class MigrationsMove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExternalDebtsAPI",
                columns: table => new
                {
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalDebtsAPI", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "ExternalDebtsInfo",
                columns: table => new
                {
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debt = table.Column<double>(type: "float", nullable: false),
                    Increase = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalDebtsInfo", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "InternalDebtsAPI",
                columns: table => new
                {
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalDebtsAPI", x => x.Time);
                });

            migrationBuilder.CreateTable(
                name: "InternalDebtsInfo",
                columns: table => new
                {
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debt = table.Column<double>(type: "float", nullable: false),
                    Increase = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalDebtsInfo", x => x.Time);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalDebtsAPI");

            migrationBuilder.DropTable(
                name: "ExternalDebtsInfo");

            migrationBuilder.DropTable(
                name: "InternalDebtsAPI");

            migrationBuilder.DropTable(
                name: "InternalDebtsInfo");
        }
    }
}
