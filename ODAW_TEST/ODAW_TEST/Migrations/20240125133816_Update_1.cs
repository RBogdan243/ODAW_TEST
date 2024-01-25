using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ODAW_TEST.Migrations
{
    /// <inheritdoc />
    public partial class Update_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfesorMaterie_Materii_ProfesorId",
                table: "ProfesorMaterie");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfesorMaterie_Profesori_MaterieId",
                table: "ProfesorMaterie");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfesorMaterie_Materii_MaterieId",
                table: "ProfesorMaterie",
                column: "MaterieId",
                principalTable: "Materii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfesorMaterie_Profesori_ProfesorId",
                table: "ProfesorMaterie",
                column: "ProfesorId",
                principalTable: "Profesori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfesorMaterie_Materii_MaterieId",
                table: "ProfesorMaterie");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfesorMaterie_Profesori_ProfesorId",
                table: "ProfesorMaterie");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfesorMaterie_Materii_ProfesorId",
                table: "ProfesorMaterie",
                column: "ProfesorId",
                principalTable: "Materii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfesorMaterie_Profesori_MaterieId",
                table: "ProfesorMaterie",
                column: "MaterieId",
                principalTable: "Profesori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
