using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_ing_soft.Migrations
{
    public partial class actualizacion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AsistenteID",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Asistio",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "ChorifestID",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Pagado",
                table: "Personas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AsistenteID",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Asistio",
                table: "Personas",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChorifestID",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Personas",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Pagado",
                table: "Personas",
                type: "tinyint(1)",
                nullable: true);
        }
    }
}
