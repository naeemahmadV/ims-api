using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.PostgreSQL.Migrations.Application
{
    /// <inheritdoc />
    public partial class forLeadPostgreSql : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statess_Country_CountryId",
                schema: "Catalog",
                table: "Statess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statess",
                schema: "Catalog",
                table: "Statess");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                schema: "Catalog",
                table: "Country");

            migrationBuilder.RenameTable(
                name: "Statess",
                schema: "Catalog",
                newName: "States",
                newSchema: "Catalog");

            migrationBuilder.RenameTable(
                name: "Country",
                schema: "Catalog",
                newName: "Countries",
                newSchema: "Catalog");

            migrationBuilder.RenameIndex(
                name: "IX_Statess_CountryId",
                schema: "Catalog",
                table: "States",
                newName: "IX_States_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_States",
                schema: "Catalog",
                table: "States",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                schema: "Catalog",
                table: "Countries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    StateId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Catalog",
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadSources",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SourceName = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadSources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    MediaGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    MimeType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    AltAttribute = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    TitleAttribute = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    PathURL = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leads",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Topic = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Designation = table.Column<string>(type: "text", nullable: true),
                    BusinessPhone = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    MobilePhone = table.Column<string>(type: "text", nullable: true),
                    JobDescription = table.Column<string>(type: "text", nullable: true),
                    CountryId = table.Column<Guid>(type: "uuid", nullable: true),
                    StateId = table.Column<Guid>(type: "uuid", nullable: true),
                    CityId = table.Column<Guid>(type: "uuid", nullable: true),
                    TimeZone = table.Column<string>(type: "text", nullable: true),
                    LeadSourceId = table.Column<Guid>(type: "uuid", nullable: true),
                    LeadStatus = table.Column<string>(type: "text", nullable: true),
                    FreeTrialOffered = table.Column<bool>(type: "boolean", nullable: false),
                    PrefferedShift = table.Column<string>(type: "text", nullable: true),
                    NumberOfResources = table.Column<int>(type: "integer", nullable: false),
                    ExpectedStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DomainORIndustry = table.Column<string>(type: "text", nullable: true),
                    Budget = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    LeadType = table.Column<string>(type: "text", nullable: true),
                    NDAShared = table.Column<bool>(type: "boolean", nullable: false),
                    NDASharedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TechnicalCoordinatorStatus = table.Column<string>(type: "text", nullable: true),
                    Company = table.Column<string>(type: "text", nullable: true),
                    CompanyAddress1 = table.Column<string>(type: "text", nullable: true),
                    CompanyAddress2 = table.Column<string>(type: "text", nullable: true),
                    CompanyPostalCode = table.Column<string>(type: "text", nullable: true),
                    CompanyAnnualRevenue = table.Column<string>(type: "text", nullable: true),
                    CompanyNumberofEmployees = table.Column<int>(type: "integer", nullable: true),
                    PreferredContactMethod = table.Column<int>(type: "integer", nullable: true),
                    FollowEmail = table.Column<bool>(type: "boolean", nullable: true),
                    DoNotEmail = table.Column<bool>(type: "boolean", nullable: true),
                    DoNotBulkEmail = table.Column<bool>(type: "boolean", nullable: true),
                    DoNotPhone = table.Column<bool>(type: "boolean", nullable: true),
                    MarkAsQualified = table.Column<bool>(type: "boolean", nullable: true),
                    QualifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    QualifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leads_Cities_CityId",
                        column: x => x.CityId,
                        principalSchema: "Catalog",
                        principalTable: "Cities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leads_Countries_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Catalog",
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leads_LeadSources_LeadSourceId",
                        column: x => x.LeadSourceId,
                        principalSchema: "Catalog",
                        principalTable: "LeadSources",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Leads_States_StateId",
                        column: x => x.StateId,
                        principalSchema: "Catalog",
                        principalTable: "States",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SubSkills",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SubSkillName = table.Column<string>(type: "text", nullable: true),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "Catalog",
                        principalTable: "Skills",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeadMedias",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LeadId = table.Column<Guid>(type: "uuid", nullable: false),
                    MediaId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadMedias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadMedias_Leads_LeadId",
                        column: x => x.LeadId,
                        principalSchema: "Catalog",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadMedias_Medias_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "Catalog",
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadSkills",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LeadId = table.Column<Guid>(type: "uuid", nullable: false),
                    SkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadSkills_Leads_LeadId",
                        column: x => x.LeadId,
                        principalSchema: "Catalog",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "Catalog",
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesCoordinators",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LeadId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesCoordinators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesCoordinators_Leads_LeadId",
                        column: x => x.LeadId,
                        principalSchema: "Catalog",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalCoordinator",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LeadId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalCoordinator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TechnicalCoordinator_Leads_LeadId",
                        column: x => x.LeadId,
                        principalSchema: "Catalog",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadSubSkills",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LeadId = table.Column<Guid>(type: "uuid", nullable: false),
                    SubSkillId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadSubSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadSubSkills_Leads_LeadId",
                        column: x => x.LeadId,
                        principalSchema: "Catalog",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadSubSkills_SubSkills_SubSkillId",
                        column: x => x.SubSkillId,
                        principalSchema: "Catalog",
                        principalTable: "SubSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                schema: "Catalog",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadMedias_LeadId",
                schema: "Catalog",
                table: "LeadMedias",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadMedias_MediaId",
                schema: "Catalog",
                table: "LeadMedias",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_CityId",
                schema: "Catalog",
                table: "Leads",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_CountryId",
                schema: "Catalog",
                table: "Leads",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_LeadSourceId",
                schema: "Catalog",
                table: "Leads",
                column: "LeadSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Leads_StateId",
                schema: "Catalog",
                table: "Leads",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadSkills_LeadId",
                schema: "Catalog",
                table: "LeadSkills",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadSkills_SkillId",
                schema: "Catalog",
                table: "LeadSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadSubSkills_LeadId",
                schema: "Catalog",
                table: "LeadSubSkills",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadSubSkills_SubSkillId",
                schema: "Catalog",
                table: "LeadSubSkills",
                column: "SubSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesCoordinators_LeadId",
                schema: "Catalog",
                table: "SalesCoordinators",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_SubSkills_SkillId",
                schema: "Catalog",
                table: "SubSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicalCoordinator_LeadId",
                schema: "Catalog",
                table: "TechnicalCoordinator",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_States_Countries_CountryId",
                schema: "Catalog",
                table: "States",
                column: "CountryId",
                principalSchema: "Catalog",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                schema: "Catalog",
                table: "States");

            migrationBuilder.DropTable(
                name: "LeadMedias",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "LeadSkills",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "LeadSubSkills",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "SalesCoordinators",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "TechnicalCoordinator",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Medias",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "SubSkills",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Leads",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Skills",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "LeadSources",
                schema: "Catalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                schema: "Catalog",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                schema: "Catalog",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "States",
                schema: "Catalog",
                newName: "Statess",
                newSchema: "Catalog");

            migrationBuilder.RenameTable(
                name: "Countries",
                schema: "Catalog",
                newName: "Country",
                newSchema: "Catalog");

            migrationBuilder.RenameIndex(
                name: "IX_States_CountryId",
                schema: "Catalog",
                table: "Statess",
                newName: "IX_Statess_CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statess",
                schema: "Catalog",
                table: "Statess",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                schema: "Catalog",
                table: "Country",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Statess_Country_CountryId",
                schema: "Catalog",
                table: "Statess",
                column: "CountryId",
                principalSchema: "Catalog",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
