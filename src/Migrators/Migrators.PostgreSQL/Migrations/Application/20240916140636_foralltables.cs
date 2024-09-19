using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Migrators.PostgreSQL.Migrations.Application
{
    /// <inheritdoc />
    public partial class foralltables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                schema: "Catalog",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Cities_CityId",
                schema: "Catalog",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Countries_CountryId",
                schema: "Catalog",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_States_StateId",
                schema: "Catalog",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_States_Countries_CountryId",
                schema: "Catalog",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_States",
                schema: "Catalog",
                table: "States");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                schema: "Catalog",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                schema: "Catalog",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "States",
                schema: "Catalog",
                newName: "State",
                newSchema: "Catalog");

            migrationBuilder.RenameTable(
                name: "Countries",
                schema: "Catalog",
                newName: "Country",
                newSchema: "Catalog");

            migrationBuilder.RenameTable(
                name: "Cities",
                schema: "Catalog",
                newName: "City",
                newSchema: "Catalog");

            migrationBuilder.RenameIndex(
                name: "IX_States_CountryId",
                schema: "Catalog",
                table: "State",
                newName: "IX_State_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_StateId",
                schema: "Catalog",
                table: "City",
                newName: "IX_City_StateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_State",
                schema: "Catalog",
                table: "State",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                schema: "Catalog",
                table: "Country",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                schema: "Catalog",
                table: "City",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AccountSource",
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
                    table.PrimaryKey("PK_AccountSource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
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
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadActivities",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LeadId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActivityType = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MarkAsTask = table.Column<bool>(type: "boolean", nullable: true),
                    TaskStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TaskDueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TaskStatus = table.Column<int>(type: "integer", nullable: true),
                    TaskCompletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AssignTo = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadActivities_Leads_LeadId",
                        column: x => x.LeadId,
                        principalSchema: "Catalog",
                        principalTable: "Leads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpportunitySource",
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
                    table.PrimaryKey("PK_OpportunitySource", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
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
                    AccountSourceId = table.Column<Guid>(type: "uuid", nullable: true),
                    AccountStatus = table.Column<string>(type: "text", nullable: true),
                    FreeTrialOffered = table.Column<bool>(type: "boolean", nullable: false),
                    PrefferedShift = table.Column<string>(type: "text", nullable: true),
                    NumberOfResources = table.Column<int>(type: "integer", nullable: false),
                    ExpectedStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DomainORIndustry = table.Column<string>(type: "text", nullable: true),
                    Budget = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    AccountType = table.Column<string>(type: "text", nullable: true),
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
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_AccountSource_AccountSourceId",
                        column: x => x.AccountSourceId,
                        principalSchema: "Catalog",
                        principalTable: "AccountSource",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Account_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Catalog",
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Account_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Catalog",
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Account_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "Catalog",
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Opportunity",
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
                    LeadId = table.Column<Guid>(type: "uuid", nullable: true),
                    TimeZone = table.Column<string>(type: "text", nullable: true),
                    OpportunitySourceId = table.Column<Guid>(type: "uuid", nullable: true),
                    OpportunityStatus = table.Column<string>(type: "text", nullable: true),
                    FreeTrialOffered = table.Column<bool>(type: "boolean", nullable: false),
                    PrefferedShift = table.Column<string>(type: "text", nullable: true),
                    NumberOfResources = table.Column<int>(type: "integer", nullable: false),
                    ExpectedStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DomainORIndustry = table.Column<string>(type: "text", nullable: true),
                    Budget = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    OpportunityType = table.Column<string>(type: "text", nullable: true),
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
                    OpportunityWon = table.Column<bool>(type: "boolean", nullable: true),
                    OpportunityLost = table.Column<bool>(type: "boolean", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opportunity_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Catalog",
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opportunity_Country_CountryId",
                        column: x => x.CountryId,
                        principalSchema: "Catalog",
                        principalTable: "Country",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opportunity_Leads_LeadId",
                        column: x => x.LeadId,
                        principalSchema: "Catalog",
                        principalTable: "Leads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opportunity_OpportunitySource_OpportunitySourceId",
                        column: x => x.OpportunitySourceId,
                        principalSchema: "Catalog",
                        principalTable: "OpportunitySource",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Opportunity_State_StateId",
                        column: x => x.StateId,
                        principalSchema: "Catalog",
                        principalTable: "State",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountActivities",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActivityType = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MarkAsTask = table.Column<bool>(type: "boolean", nullable: true),
                    TaskStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TaskDueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TaskStatus = table.Column<int>(type: "integer", nullable: true),
                    TaskCompletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AssignTo = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountActivities_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Catalog",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountMedia",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_AccountMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountMedia_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Catalog",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountMedia_Medias_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "Catalog",
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountSalesCoordinator",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_AccountSalesCoordinator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountSalesCoordinator_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Catalog",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountSkill",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_AccountSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountSkill_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Catalog",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountSkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "Catalog",
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountSubSkills",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_AccountSubSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountSubSkills_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Catalog",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountSubSkills_SubSkills_SubSkillId",
                        column: x => x.SubSkillId,
                        principalSchema: "Catalog",
                        principalTable: "SubSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTechnicalCoordinator",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_AccountTechnicalCoordinator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTechnicalCoordinator_Account_AccountId",
                        column: x => x.AccountId,
                        principalSchema: "Catalog",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpportunityActivities",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OpportunityId = table.Column<Guid>(type: "uuid", nullable: false),
                    ActivityType = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MarkAsTask = table.Column<bool>(type: "boolean", nullable: true),
                    TaskStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TaskDueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TaskStatus = table.Column<int>(type: "integer", nullable: true),
                    TaskCompletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AssignTo = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpportunityActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpportunityActivities_Opportunity_OpportunityId",
                        column: x => x.OpportunityId,
                        principalSchema: "Catalog",
                        principalTable: "Opportunity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpportunityMedia",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OpportunityId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_OpportunityMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpportunityMedia_Medias_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "Catalog",
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpportunityMedia_Opportunity_OpportunityId",
                        column: x => x.OpportunityId,
                        principalSchema: "Catalog",
                        principalTable: "Opportunity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpportunitySalesCoordinator",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OpportunityId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_OpportunitySalesCoordinator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpportunitySalesCoordinator_Opportunity_OpportunityId",
                        column: x => x.OpportunityId,
                        principalSchema: "Catalog",
                        principalTable: "Opportunity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpportunitySkill",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OpportunityId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_OpportunitySkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpportunitySkill_Opportunity_OpportunityId",
                        column: x => x.OpportunityId,
                        principalSchema: "Catalog",
                        principalTable: "Opportunity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpportunitySkill_Skills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "Catalog",
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpportunitySubSkill",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OpportunityId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_OpportunitySubSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpportunitySubSkill_Opportunity_OpportunityId",
                        column: x => x.OpportunityId,
                        principalSchema: "Catalog",
                        principalTable: "Opportunity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpportunitySubSkill_SubSkills_SubSkillId",
                        column: x => x.SubSkillId,
                        principalSchema: "Catalog",
                        principalTable: "SubSkills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpportunityTechnicalCoordinator",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OpportunityId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_OpportunityTechnicalCoordinator", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpportunityTechnicalCoordinator_Opportunity_OpportunityId",
                        column: x => x.OpportunityId,
                        principalSchema: "Catalog",
                        principalTable: "Opportunity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityMedia",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LeadActivitiesId = table.Column<Guid>(type: "uuid", nullable: false),
                    AccountActivitiesId = table.Column<Guid>(type: "uuid", nullable: false),
                    OpportunityActivitiesId = table.Column<Guid>(type: "uuid", nullable: false),
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
                    table.PrimaryKey("PK_ActivityMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityMedia_AccountActivities_AccountActivitiesId",
                        column: x => x.AccountActivitiesId,
                        principalSchema: "Catalog",
                        principalTable: "AccountActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityMedia_LeadActivities_LeadActivitiesId",
                        column: x => x.LeadActivitiesId,
                        principalSchema: "Catalog",
                        principalTable: "LeadActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityMedia_Medias_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "Catalog",
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityMedia_OpportunityActivities_OpportunityActivitiesId",
                        column: x => x.OpportunityActivitiesId,
                        principalSchema: "Catalog",
                        principalTable: "OpportunityActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountSourceId",
                schema: "Catalog",
                table: "Account",
                column: "AccountSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_CityId",
                schema: "Catalog",
                table: "Account",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_CountryId",
                schema: "Catalog",
                table: "Account",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_StateId",
                schema: "Catalog",
                table: "Account",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountActivities_AccountId",
                schema: "Catalog",
                table: "AccountActivities",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountMedia_AccountId",
                schema: "Catalog",
                table: "AccountMedia",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountMedia_MediaId",
                schema: "Catalog",
                table: "AccountMedia",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSalesCoordinator_AccountId",
                schema: "Catalog",
                table: "AccountSalesCoordinator",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSkill_AccountId",
                schema: "Catalog",
                table: "AccountSkill",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSkill_SkillId",
                schema: "Catalog",
                table: "AccountSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSubSkills_AccountId",
                schema: "Catalog",
                table: "AccountSubSkills",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountSubSkills_SubSkillId",
                schema: "Catalog",
                table: "AccountSubSkills",
                column: "SubSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTechnicalCoordinator_AccountId",
                schema: "Catalog",
                table: "AccountTechnicalCoordinator",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMedia_AccountActivitiesId",
                schema: "Catalog",
                table: "ActivityMedia",
                column: "AccountActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMedia_LeadActivitiesId",
                schema: "Catalog",
                table: "ActivityMedia",
                column: "LeadActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMedia_MediaId",
                schema: "Catalog",
                table: "ActivityMedia",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityMedia_OpportunityActivitiesId",
                schema: "Catalog",
                table: "ActivityMedia",
                column: "OpportunityActivitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadActivities_LeadId",
                schema: "Catalog",
                table: "LeadActivities",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_CityId",
                schema: "Catalog",
                table: "Opportunity",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_CountryId",
                schema: "Catalog",
                table: "Opportunity",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_LeadId",
                schema: "Catalog",
                table: "Opportunity",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_OpportunitySourceId",
                schema: "Catalog",
                table: "Opportunity",
                column: "OpportunitySourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_StateId",
                schema: "Catalog",
                table: "Opportunity",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityActivities_OpportunityId",
                schema: "Catalog",
                table: "OpportunityActivities",
                column: "OpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityMedia_MediaId",
                schema: "Catalog",
                table: "OpportunityMedia",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityMedia_OpportunityId",
                schema: "Catalog",
                table: "OpportunityMedia",
                column: "OpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunitySalesCoordinator_OpportunityId",
                schema: "Catalog",
                table: "OpportunitySalesCoordinator",
                column: "OpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunitySkill_OpportunityId",
                schema: "Catalog",
                table: "OpportunitySkill",
                column: "OpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunitySkill_SkillId",
                schema: "Catalog",
                table: "OpportunitySkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunitySubSkill_OpportunityId",
                schema: "Catalog",
                table: "OpportunitySubSkill",
                column: "OpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunitySubSkill_SubSkillId",
                schema: "Catalog",
                table: "OpportunitySubSkill",
                column: "SubSkillId");

            migrationBuilder.CreateIndex(
                name: "IX_OpportunityTechnicalCoordinator_OpportunityId",
                schema: "Catalog",
                table: "OpportunityTechnicalCoordinator",
                column: "OpportunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_State_StateId",
                schema: "Catalog",
                table: "City",
                column: "StateId",
                principalSchema: "Catalog",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_City_CityId",
                schema: "Catalog",
                table: "Leads",
                column: "CityId",
                principalSchema: "Catalog",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Country_CountryId",
                schema: "Catalog",
                table: "Leads",
                column: "CountryId",
                principalSchema: "Catalog",
                principalTable: "Country",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_State_StateId",
                schema: "Catalog",
                table: "Leads",
                column: "StateId",
                principalSchema: "Catalog",
                principalTable: "State",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_CountryId",
                schema: "Catalog",
                table: "State",
                column: "CountryId",
                principalSchema: "Catalog",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_State_StateId",
                schema: "Catalog",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_City_CityId",
                schema: "Catalog",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_Country_CountryId",
                schema: "Catalog",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_Leads_State_StateId",
                schema: "Catalog",
                table: "Leads");

            migrationBuilder.DropForeignKey(
                name: "FK_State_Country_CountryId",
                schema: "Catalog",
                table: "State");

            migrationBuilder.DropTable(
                name: "AccountMedia",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AccountSalesCoordinator",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AccountSkill",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AccountSubSkills",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AccountTechnicalCoordinator",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ActivityMedia",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Companies",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "OpportunityMedia",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "OpportunitySalesCoordinator",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "OpportunitySkill",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "OpportunitySubSkill",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "OpportunityTechnicalCoordinator",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AccountActivities",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "LeadActivities",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "OpportunityActivities",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "Opportunity",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "AccountSource",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "OpportunitySource",
                schema: "Catalog");

            migrationBuilder.DropPrimaryKey(
                name: "PK_State",
                schema: "Catalog",
                table: "State");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                schema: "Catalog",
                table: "Country");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                schema: "Catalog",
                table: "City");

            migrationBuilder.RenameTable(
                name: "State",
                schema: "Catalog",
                newName: "States",
                newSchema: "Catalog");

            migrationBuilder.RenameTable(
                name: "Country",
                schema: "Catalog",
                newName: "Countries",
                newSchema: "Catalog");

            migrationBuilder.RenameTable(
                name: "City",
                schema: "Catalog",
                newName: "Cities",
                newSchema: "Catalog");

            migrationBuilder.RenameIndex(
                name: "IX_State_CountryId",
                schema: "Catalog",
                table: "States",
                newName: "IX_States_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_City_StateId",
                schema: "Catalog",
                table: "Cities",
                newName: "IX_Cities_StateId");

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                schema: "Catalog",
                table: "Cities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                schema: "Catalog",
                table: "Cities",
                column: "StateId",
                principalSchema: "Catalog",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Cities_CityId",
                schema: "Catalog",
                table: "Leads",
                column: "CityId",
                principalSchema: "Catalog",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_Countries_CountryId",
                schema: "Catalog",
                table: "Leads",
                column: "CountryId",
                principalSchema: "Catalog",
                principalTable: "Countries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leads_States_StateId",
                schema: "Catalog",
                table: "Leads",
                column: "StateId",
                principalSchema: "Catalog",
                principalTable: "States",
                principalColumn: "Id");

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
    }
}
