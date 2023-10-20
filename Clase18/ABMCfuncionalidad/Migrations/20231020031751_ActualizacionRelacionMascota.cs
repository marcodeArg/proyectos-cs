using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABMCfuncionalidad.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionRelacionMascota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdMascota",
                table: "AtencionMedicas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdMascota",
                table: "AtencionMedicas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
