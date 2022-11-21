using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraktikPortalWebApi.Migrations
{
    public partial class foreignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_internship_student_Studentid",
                table: "internship");

            migrationBuilder.RenameColumn(
                name: "Studentid",
                table: "internship",
                newName: "student_id");

            migrationBuilder.RenameIndex(
                name: "IX_internship_Studentid",
                table: "internship",
                newName: "IX_internship_student_id");

            migrationBuilder.AddForeignKey(
                name: "FK_internship_student_student_id",
                table: "internship",
                column: "student_id",
                principalTable: "student",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_internship_student_student_id",
                table: "internship");

            migrationBuilder.RenameColumn(
                name: "student_id",
                table: "internship",
                newName: "Studentid");

            migrationBuilder.RenameIndex(
                name: "IX_internship_student_id",
                table: "internship",
                newName: "IX_internship_Studentid");

            migrationBuilder.AddForeignKey(
                name: "FK_internship_student_Studentid",
                table: "internship",
                column: "Studentid",
                principalTable: "student",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
