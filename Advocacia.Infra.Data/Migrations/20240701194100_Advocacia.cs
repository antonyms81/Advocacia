using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Advocacia.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Advocacia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(2)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(14)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(14)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
