using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DebtAPI.Migrations
{
    public partial class ExternalDebtMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebtAPIInfos");

            migrationBuilder.DropTable(
                name: "DebtInfos");

            migrationBuilder.CreateTable(
                name: "ExternalDebtsAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalDebtsAPI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalDebtsInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debt = table.Column<double>(type: "float", nullable: false),
                    Increase = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalDebtsInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalDebtsAPI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalDebtsAPI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InternalDebtsInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debt = table.Column<double>(type: "float", nullable: false),
                    Increase = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalDebtsInfo", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "DebtAPIInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debt = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtAPIInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DebtInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Debt = table.Column<double>(type: "float", nullable: false),
                    Increase = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebtInfos", x => x.Id);
                });
        }
    }
}
