using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AplikasiUploadExcel.Api.Migrations
{
    /// <inheritdoc />
    public partial class org_dept : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Org_Dept",
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
                    Code = table.Column<int>(type: "int", nullable: false),
                    ChangeTrackingMask = table.Column<int>(type: "int", nullable: false),
                    OrgCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Org_Dept", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Org_Dept");
        }
    }
}
