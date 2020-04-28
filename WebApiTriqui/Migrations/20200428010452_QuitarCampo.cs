using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiTriqui.Migrations
{
    public partial class QuitarCampo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipoIdentificacion_Usuarios_UsuarioId",
                table: "TipoIdentificacion");

            migrationBuilder.DropIndex(
                name: "IX_TipoIdentificacion_UsuarioId",
                table: "TipoIdentificacion");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TipoIdentificacion");

            migrationBuilder.AlterColumn<string>(
                name: "Contrasena",
                table: "Usuarios",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "TipoIdentificacionId",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoIdentificacionId",
                table: "Usuarios",
                column: "TipoIdentificacionId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TipoIdentificacion_TipoIdentificacionId",
                table: "Usuarios",
                column: "TipoIdentificacionId",
                principalTable: "TipoIdentificacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoIdentificacion_TipoIdentificacionId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TipoIdentificacionId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TipoIdentificacionId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Contrasena",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "TipoIdentificacion",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TipoIdentificacion_UsuarioId",
                table: "TipoIdentificacion",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TipoIdentificacion_Usuarios_UsuarioId",
                table: "TipoIdentificacion",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
