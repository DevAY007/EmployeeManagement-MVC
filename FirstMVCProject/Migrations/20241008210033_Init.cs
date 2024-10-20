using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstMVCProject.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_emlpoyees_CompanyReg_CompanyRegistrationId",
                table: "emlpoyees");

            migrationBuilder.DropTable(
                name: "WorkStatus");

            migrationBuilder.DropIndex(
                name: "IX_emlpoyees_CompanyRegistrationId",
                table: "emlpoyees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyReg",
                table: "CompanyReg");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "NextKin");

            migrationBuilder.DropColumn(
                name: "EducationStatus",
                table: "NextKin");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "NextKin");

            migrationBuilder.DropColumn(
                name: "HomePhoneNumber",
                table: "NextKin");

            migrationBuilder.DropColumn(
                name: "HealthStatus",
                table: "HealthStatus");

            migrationBuilder.DropColumn(
                name: "CompanyRegistrationId",
                table: "emlpoyees");

            migrationBuilder.DropColumn(
                name: "InstitutionGmail",
                table: "EduInformation");

            migrationBuilder.DropColumn(
                name: "PrimarySchoolGmail",
                table: "EduInformation");

            migrationBuilder.DropColumn(
                name: "Qualifications",
                table: "EduInformation");

            migrationBuilder.RenameTable(
                name: "CompanyReg",
                newName: "CompanyRegistration");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "NextKin",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "SecondarySchoolGmail",
                table: "EduInformation",
                newName: "Qualification");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "NextKin",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "HealthStatus",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "emlpoyees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "EduInformation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyRegistration",
                table: "CompanyRegistration",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NextKin_EmployeeId",
                table: "NextKin",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthStatus_EmployeeId",
                table: "HealthStatus",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_emlpoyees_CompanyId",
                table: "emlpoyees",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_EduInformation_EmployeeId",
                table: "EduInformation",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EduInformation_emlpoyees_EmployeeId",
                table: "EduInformation",
                column: "EmployeeId",
                principalTable: "emlpoyees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_emlpoyees_CompanyRegistration_CompanyId",
                table: "emlpoyees",
                column: "CompanyId",
                principalTable: "CompanyRegistration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthStatus_emlpoyees_EmployeeId",
                table: "HealthStatus",
                column: "EmployeeId",
                principalTable: "emlpoyees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NextKin_emlpoyees_EmployeeId",
                table: "NextKin",
                column: "EmployeeId",
                principalTable: "emlpoyees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EduInformation_emlpoyees_EmployeeId",
                table: "EduInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_emlpoyees_CompanyRegistration_CompanyId",
                table: "emlpoyees");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthStatus_emlpoyees_EmployeeId",
                table: "HealthStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_NextKin_emlpoyees_EmployeeId",
                table: "NextKin");

            migrationBuilder.DropIndex(
                name: "IX_NextKin_EmployeeId",
                table: "NextKin");

            migrationBuilder.DropIndex(
                name: "IX_HealthStatus_EmployeeId",
                table: "HealthStatus");

            migrationBuilder.DropIndex(
                name: "IX_emlpoyees_CompanyId",
                table: "emlpoyees");

            migrationBuilder.DropIndex(
                name: "IX_EduInformation_EmployeeId",
                table: "EduInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyRegistration",
                table: "CompanyRegistration");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "NextKin");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "HealthStatus");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "emlpoyees");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "EduInformation");

            migrationBuilder.RenameTable(
                name: "CompanyRegistration",
                newName: "CompanyReg");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "NextKin",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Qualification",
                table: "EduInformation",
                newName: "SecondarySchoolGmail");

            migrationBuilder.AddColumn<string>(
                name: "DOB",
                table: "NextKin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EducationStatus",
                table: "NextKin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "NextKin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HomePhoneNumber",
                table: "NextKin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HealthStatus",
                table: "HealthStatus",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyRegistrationId",
                table: "emlpoyees",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstitutionGmail",
                table: "EduInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimarySchoolGmail",
                table: "EduInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Qualifications",
                table: "EduInformation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyReg",
                table: "CompanyReg",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "WorkStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyGmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionHeld = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForQuiting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkStatus", x => x.Id);
                });

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
    }
}
