using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.PostgreSQL.Migrations.Application
{
    /// <inheritdoc />
    public partial class forAddState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Country",
            //    schema: "Catalog",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uuid", nullable: false),
            //        Name = table.Column<string>(type: "text", nullable: true),
            //        Code = table.Column<string>(type: "text", nullable: false),
            //        CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
            //        CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
            //        LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
            //        LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
            //        DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
            //        DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Country", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "Statess",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statess_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Catalog",
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statess_CountryId",
                schema: "Catalog",
                table: "Statess",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statess",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "Catalog");
        }
    }
}
