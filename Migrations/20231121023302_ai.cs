using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppDeEventos.Migrations
{
    /// <inheritdoc />
    public partial class ai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    IdAdministrador = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Organizador = table.Column<bool>(type: "boolean", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.IdAdministrador);
                });

            migrationBuilder.CreateTable(
                name: "Visitantes",
                columns: table => new
                {
                    IdVisitante = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitantes", x => x.IdVisitante);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    IdEvento = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizadorId = table.Column<int>(type: "integer", nullable: false),
                    Palestrante = table.Column<string>(type: "text", nullable: false),
                    titulo = table.Column<string>(type: "text", nullable: false),
                    descricao = table.Column<string>(type: "text", nullable: false),
                    Banner = table.Column<string>(type: "text", nullable: false),
                    Local = table.Column<string>(type: "text", nullable: false),
                    Data = table.Column<DateOnly>(type: "date", nullable: false),
                    Duracao = table.Column<double>(type: "double precision", nullable: false),
                    numMaxParticipantes = table.Column<int>(type: "integer", nullable: false),
                    Disponivel = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_Eventos_Administradores_OrganizadorId",
                        column: x => x.OrganizadorId,
                        principalTable: "Administradores",
                        principalColumn: "IdAdministrador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventoVisitantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VisitanteIdVisitante = table.Column<int>(type: "integer", nullable: false),
                    IdVisitante = table.Column<int>(type: "integer", nullable: false),
                    AdministradorIdAdministrador = table.Column<int>(type: "integer", nullable: false),
                    IdAdministrador = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoVisitantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventoVisitantes_Administradores_AdministradorIdAdministrad~",
                        column: x => x.AdministradorIdAdministrador,
                        principalTable: "Administradores",
                        principalColumn: "IdAdministrador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoVisitantes_Visitantes_VisitanteIdVisitante",
                        column: x => x.VisitanteIdVisitante,
                        principalTable: "Visitantes",
                        principalColumn: "IdVisitante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventoVisitante",
                columns: table => new
                {
                    EventosIdEvento = table.Column<int>(type: "integer", nullable: false),
                    ListaParticipantesIdVisitante = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventoVisitante", x => new { x.EventosIdEvento, x.ListaParticipantesIdVisitante });
                    table.ForeignKey(
                        name: "FK_EventoVisitante_Eventos_EventosIdEvento",
                        column: x => x.EventosIdEvento,
                        principalTable: "Eventos",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventoVisitante_Visitantes_ListaParticipantesIdVisitante",
                        column: x => x.ListaParticipantesIdVisitante,
                        principalTable: "Visitantes",
                        principalColumn: "IdVisitante",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_OrganizadorId",
                table: "Eventos",
                column: "OrganizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_EventoVisitante_ListaParticipantesIdVisitante",
                table: "EventoVisitante",
                column: "ListaParticipantesIdVisitante");

            migrationBuilder.CreateIndex(
                name: "IX_EventoVisitantes_AdministradorIdAdministrador",
                table: "EventoVisitantes",
                column: "AdministradorIdAdministrador");

            migrationBuilder.CreateIndex(
                name: "IX_EventoVisitantes_VisitanteIdVisitante",
                table: "EventoVisitantes",
                column: "VisitanteIdVisitante");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventoVisitante");

            migrationBuilder.DropTable(
                name: "EventoVisitantes");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Visitantes");

            migrationBuilder.DropTable(
                name: "Administradores");
        }
    }
}
