using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace api_ing_soft.Migrations
{
    public partial class marti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bebidas",
                columns: table => new
                {
                    BebidaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Linea = table.Column<string>(type: "longtext", nullable: false),
                    Tipo = table.Column<string>(type: "longtext", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Alcoholica = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Litros = table.Column<double>(type: "double", nullable: false),
                    FechaFabricacion = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebidas", x => x.BebidaID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Chorifests",
                columns: table => new
                {
                    ChorifestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MenuID = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Chorifests", x => x.ChorifestID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Choris",
                columns: table => new
                {
                    ChoriPanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    LlevaTomate = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LLevaLechuga = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LLevaAderezo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EsCarne = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EsVegano = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EsPan = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choris", x => x.ChoriPanID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    PersonaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    Apellido = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.PersonaID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ChorifestID = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "longtext", nullable: false),
                    ChoriPanID = table.Column<int>(type: "int", nullable: true),
                    BebidaID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuID);
                    table.ForeignKey(
                        name: "FK_Menu_Bebidas_BebidaID",
                        column: x => x.BebidaID,
                        principalTable: "Bebidas",
                        principalColumn: "BebidaID");
                    table.ForeignKey(
                        name: "FK_Menu_Choris_ChoriPanID",
                        column: x => x.ChoriPanID,
                        principalTable: "Choris",
                        principalColumn: "ChoriPanID");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PersonaID = table.Column<int>(type: "int", nullable: false),
                    Contraseña = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admin_Personas_PersonaID",
                        column: x => x.PersonaID,
                        principalTable: "Personas",
                        principalColumn: "PersonaID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Asistentes",
                columns: table => new
                {
                    AsistenteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PersonaID = table.Column<int>(type: "int", nullable: false),
                    Asistio = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Pagado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ChorifestID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asistentes", x => x.AsistenteID);
                    table.ForeignKey(
                        name: "FK_Asistentes_Personas_PersonaID",
                        column: x => x.PersonaID,
                        principalTable: "Personas",
                        principalColumn: "PersonaID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_PersonaID",
                table: "Admin",
                column: "PersonaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Asistentes_PersonaID",
                table: "Asistentes",
                column: "PersonaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menu_BebidaID",
                table: "Menu",
                column: "BebidaID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_ChoriPanID",
                table: "Menu",
                column: "ChoriPanID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Asistentes");

            migrationBuilder.DropTable(
                name: "Chorifests");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Bebidas");

            migrationBuilder.DropTable(
                name: "Choris");
        }
    }
}
