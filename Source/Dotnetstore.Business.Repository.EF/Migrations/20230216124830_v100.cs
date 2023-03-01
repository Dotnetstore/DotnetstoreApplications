using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dotnetstore.Business.Repository.EF.Migrations
{
    /// <inheritdoc />
    public partial class v100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OwnCompanies",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
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
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    CorporateID = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnCompanies", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwnCompanies_ID",
                table: "OwnCompanies",
                column: "ID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnCompanies");
        }
    }
}
