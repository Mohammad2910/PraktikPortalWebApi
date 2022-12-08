using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PraktikPortalWebApi.Migrations
{
    public partial class user_ids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanySupervisor_id",
                table: "internship",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DTUSupervisor_id",
                table: "internship",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_internship_CompanySupervisor_id",
                table: "internship",
                column: "CompanySupervisor_id");

            migrationBuilder.CreateIndex(
                name: "IX_internship_DTUSupervisor_id",
                table: "internship",
                column: "DTUSupervisor_id");

            migrationBuilder.AddForeignKey(
                name: "FK_internship_user_CompanySupervisor_id",
                table: "internship",
                column: "CompanySupervisor_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_internship_user_DTUSupervisor_id",
                table: "internship",
                column: "DTUSupervisor_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_internship_user_CompanySupervisor_id",
                table: "internship");

            migrationBuilder.DropForeignKey(
                name: "FK_internship_user_DTUSupervisor_id",
                table: "internship");

            migrationBuilder.DropIndex(
                name: "IX_internship_CompanySupervisor_id",
                table: "internship");

            migrationBuilder.DropIndex(
                name: "IX_internship_DTUSupervisor_id",
                table: "internship");

            migrationBuilder.DropColumn(
                name: "CompanySupervisor_id",
                table: "internship");

            migrationBuilder.DropColumn(
                name: "DTUSupervisor_id",
                table: "internship");
        }
    }
}
