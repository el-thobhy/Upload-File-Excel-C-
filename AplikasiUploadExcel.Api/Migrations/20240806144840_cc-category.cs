using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiUploadExcel.Api.Migrations
{
    /// <inheritdoc />
    public partial class cccategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Dob",
                table: "Biodata",
                type: "datetime2",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateTable(
                name: "CC_Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionNumber = table.Column<int>(type: "int", nullable: false),
                    Version_ID = table.Column<int>(type: "int", nullable: false),
                    VersionFlag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangeTrackingMask = table.Column<int>(type: "int", nullable: false),
                    CodeCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnterDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnterUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnterVersionNumber = table.Column<int>(type: "int", nullable: false),
                    LastChgDateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastChgUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastChgVersionNumber = table.Column<int>(type: "int", nullable: false),
                    ValidationStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CC_Category", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CC_Category");

            migrationBuilder.AlterColumn<string>(
                name: "Dob",
                table: "Biodata",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 10);
        }
    }
}
