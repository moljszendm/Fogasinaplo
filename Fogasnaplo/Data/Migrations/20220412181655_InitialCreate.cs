using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fogasnaplo.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Csapatnev",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HorgaszIgazolvany",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KeresztNev",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VezetekNev",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fogas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nev = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    CsapatNev = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Ido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HalFajtak = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suly = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Allasok = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fogas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fogas");

            migrationBuilder.DropColumn(
                name: "Csapatnev",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HorgaszIgazolvany",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KeresztNev",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VezetekNev",
                table: "AspNetUsers");
        }
    }
}
