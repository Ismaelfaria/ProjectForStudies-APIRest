using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoParaEstudo.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dev_Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descrição = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datadeinicio = table.Column<DateTime>(name: "Data de inicio", type: "datetime2", nullable: false),
                    Datadefim = table.Column<DateTime>(name: "Data de fim", type: "datetime2", nullable: false),
                    Foicancelado = table.Column<bool>(name: "Foi cancelado", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dev_Events", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dev_Events");
        }
    }
}
