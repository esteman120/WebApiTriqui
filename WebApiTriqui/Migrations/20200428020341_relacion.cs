using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiTriqui.Migrations
{
    public partial class relacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoIdentificacion_TipoIdentificacionId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TipoIdentificacionId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoIdentificacion",
                table: "TipoIdentificacion");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TipoIdentificacion");

            migrationBuilder.AlterColumn<string>(
                name: "TipoIdentificacionId",
                table: "Usuarios",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "TipoIdentificacion",
                table: "TipoIdentificacion",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoIdentificacion",
                table: "TipoIdentificacion",
                column: "TipoIdentificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TipoIdentificacionId",
                table: "Usuarios",
                column: "TipoIdentificacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TipoIdentificacion_TipoIdentificacionId",
                table: "Usuarios",
                column: "TipoIdentificacionId",
                principalTable: "TipoIdentificacion",
                principalColumn: "TipoIdentificacion",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TipoIdentificacion_TipoIdentificacionId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_TipoIdentificacionId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipoIdentificacion",
                table: "TipoIdentificacion");

            migrationBuilder.AlterColumn<int>(
                name: "TipoIdentificacionId",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TipoIdentificacion",
                table: "TipoIdentificacion",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TipoIdentificacion",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipoIdentificacion",
                table: "TipoIdentificacion",
                column: "Id");

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
    }
}
