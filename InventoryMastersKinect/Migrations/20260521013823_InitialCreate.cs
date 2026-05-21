using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryMastersKinect.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicoesVolume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VolumeCm3 = table.Column<double>(type: "REAL", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    KinectLigado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Calibrado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoesVolume", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicoesVolume");
        }
    }
}
