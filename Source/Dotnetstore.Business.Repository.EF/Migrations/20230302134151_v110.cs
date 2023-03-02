using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dotnetstore.Business.Repository.EF.Migrations
{
    /// <inheritdoc />
    public partial class v110 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    OwnCompanyID = table.Column<Guid>(type: "TEXT", nullable: false),
                    IsDisposed = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedByID = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    DeletedByID = table.Column<Guid>(type: "TEXT", nullable: true),
                    DeletedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsGDPR = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsSystem = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsUpdated = table.Column<bool>(type: "INTEGER", nullable: true),
                    IsVisible = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastUpdatedByID = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastUpdatedDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    RegisterEmailAddress = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    LastNameFirst = table.Column<bool>(type: "INTEGER", nullable: false),
                    SocialSecurityNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    EnglishName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Username = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true),
                    Password = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employees_OwnCompanies_OwnCompanyID",
                        column: x => x.OwnCompanyID,
                        principalTable: "OwnCompanies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ID",
                table: "Employees",
                column: "ID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OwnCompanyID",
                table: "Employees",
                column: "OwnCompanyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
