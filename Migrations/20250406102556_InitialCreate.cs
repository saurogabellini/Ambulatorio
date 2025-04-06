using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmbulatorioApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operatori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cognome = table.Column<string>(type: "varchar(max)", maxLength: 100, nullable: false),
                    Nome = table.Column<string>(type: "varchar(max)", maxLength: 100, nullable: false),
                    CodiceFiscale = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false),
                    Recapiti = table.Column<string>(type: "varchar(max)", maxLength: 200, nullable: false),
                    Specializzazione = table.Column<string>(type: "varchar(max)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operatori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servizi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(max)", maxLength: 100, nullable: false),
                    Descrizione = table.Column<string>(type: "varchar(max)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servizi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assenze",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatoreId = table.Column<int>(type: "int", nullable: false),
                    DataOraInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataOraFine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motivo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assenze", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assenze_Operatori_OperatoreId",
                        column: x => x.OperatoreId,
                        principalTable: "Operatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SlotDisponibilita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatoreId = table.Column<int>(type: "int", nullable: false),
                    ServizioId = table.Column<int>(type: "int", nullable: false),
                    GiornoSettimana = table.Column<int>(type: "int", nullable: false),
                    OraInizio = table.Column<string>(type: "varchar(max)", nullable: false),
                    OraFine = table.Column<string>(type: "varchar(max)", nullable: false),
                    DurataMinuti = table.Column<int>(type: "int", nullable: false),
                    Attivo = table.Column<bool>(type: "bit", nullable: false),
                    DataInizioValidita = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataFineValidita = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CicloGiorni = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlotDisponibilita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SlotDisponibilita_Operatori_OperatoreId",
                        column: x => x.OperatoreId,
                        principalTable: "Operatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SlotDisponibilita_Servizi_ServizioId",
                        column: x => x.ServizioId,
                        principalTable: "Servizi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prenotazioni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatoreId = table.Column<int>(type: "int", nullable: false),
                    ServizioId = table.Column<int>(type: "int", nullable: false),
                    SlotDisponibilitaId = table.Column<int>(type: "int", nullable: false),
                    DataPrenotazione = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataOraInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataOraFine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NomeCliente = table.Column<string>(type: "varchar(max)", maxLength: 100, nullable: false),
                    CognomeCliente = table.Column<string>(type: "varchar(max)", maxLength: 100, nullable: false),
                    TelefonoCliente = table.Column<string>(type: "varchar(max)", maxLength: 20, nullable: false),
                    EmailCliente = table.Column<string>(type: "varchar(max)", maxLength: 100, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenotazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prenotazioni_Operatori_OperatoreId",
                        column: x => x.OperatoreId,
                        principalTable: "Operatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prenotazioni_Servizi_ServizioId",
                        column: x => x.ServizioId,
                        principalTable: "Servizi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prenotazioni_SlotDisponibilita_SlotDisponibilitaId",
                        column: x => x.SlotDisponibilitaId,
                        principalTable: "SlotDisponibilita",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assenze_OperatoreId",
                table: "Assenze",
                column: "OperatoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_OperatoreId",
                table: "Prenotazioni",
                column: "OperatoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_ServizioId",
                table: "Prenotazioni",
                column: "ServizioId");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_SlotDisponibilitaId",
                table: "Prenotazioni",
                column: "SlotDisponibilitaId");

            migrationBuilder.CreateIndex(
                name: "IX_SlotDisponibilita_OperatoreId",
                table: "SlotDisponibilita",
                column: "OperatoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SlotDisponibilita_ServizioId",
                table: "SlotDisponibilita",
                column: "ServizioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assenze");

            migrationBuilder.DropTable(
                name: "Prenotazioni");

            migrationBuilder.DropTable(
                name: "SlotDisponibilita");

            migrationBuilder.DropTable(
                name: "Operatori");

            migrationBuilder.DropTable(
                name: "Servizi");
        }
    }
}
