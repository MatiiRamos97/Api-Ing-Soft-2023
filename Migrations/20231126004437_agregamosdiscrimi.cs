using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace api_ing_soft.Migrations
{
    public partial class agregamosdiscrimi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Personas",
                newName: "TipoPersona");

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

            migrationBuilder.CreateTable(
                name: "Bebidas",
                columns: table => new
                {
                    IdBebida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false),
                    Precio = table.Column<float>(type: "float", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ConHielo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebidas", x => x.IdBebida);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Chorifests",
                columns: table => new
                {
                    IDChorifest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(type: "longtext", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    InicioFechaInscripcion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FinFechaInscripcion = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CantidadAsistentes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chorifests", x => x.IDChorifest);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Choris",
                columns: table => new
                {
                    IdChori = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    EsVegano = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false),
                    Precio = table.Column<float>(type: "float", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ConPapas = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choris", x => x.IdChori);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    IdMenu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false),
                    TieneExtra = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EsVegano = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.IdMenu);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<string>(type: "varchar(255)", nullable: false),
                    Descripcion = table.Column<string>(type: "longtext", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Precio = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bebidas");

            migrationBuilder.DropTable(
                name: "Chorifests");

            migrationBuilder.DropTable(
                name: "Choris");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Producto");

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

            migrationBuilder.RenameColumn(
                name: "TipoPersona",
                table: "Personas",
                newName: "Discriminator");
        }
    }
}
