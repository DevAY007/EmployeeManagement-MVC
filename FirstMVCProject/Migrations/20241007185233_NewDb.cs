using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstMVCProject.Migrations
{
    /// <inheritdoc />
    public partial class NewDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "emlpoyees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "EduInformation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimarySchoolAttended = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimarySchoolGmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondarySchoolAttended = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondarySchoolGmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstitutionAttended = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstitutionGmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateGraduated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EduInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precautions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NextKin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HomePhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EducationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NextKin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyGmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionHeld = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResumeDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReasonForQuiting = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkStatus", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EduInformation");

            migrationBuilder.DropTable(
                name: "HealthStatus");

            migrationBuilder.DropTable(
                name: "NextKin");

            migrationBuilder.DropTable(
                name: "WorkStatus");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "emlpoyees");
        }
    }
}
