using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstMVCProject.Migrations
{
    /// <inheritdoc />
    public partial class NewlyUpdatedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompanyRegistrationId",
                table: "emlpoyees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_emlpoyees_CompanyRegistrationId",
                table: "emlpoyees",
                column: "CompanyRegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_emlpoyees_CompanyReg_CompanyRegistrationId",
                table: "emlpoyees",
                column: "CompanyRegistrationId",
                principalTable: "CompanyReg",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_emlpoyees_CompanyReg_CompanyRegistrationId",
                table: "emlpoyees");

            migrationBuilder.DropIndex(
                name: "IX_emlpoyees_CompanyRegistrationId",
                table: "emlpoyees");

            migrationBuilder.DropColumn(
                name: "CompanyRegistrationId",
                table: "emlpoyees");
        }
    }
}
