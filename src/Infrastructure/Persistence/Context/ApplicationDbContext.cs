using Finbuckle.MultiTenant;
using FSH.WebApi.Application.Common.Events;
using FSH.WebApi.Application.Common.Interfaces;
using FSH.WebApi.Domain.Catalog;
using FSH.WebApi.Infrastructure.Persistence.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FSH.WebApi.Infrastructure.Persistence.Context;

public class ApplicationDbContext : BaseDbContext
{
    public ApplicationDbContext(ITenantInfo currentTenant, DbContextOptions options, ICurrentUser currentUser, ISerializerService serializer, IOptions<DatabaseSettings> dbSettings, IEventPublisher events)
        : base(currentTenant, options, currentUser, serializer, dbSettings, events)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<State> States => Set<State>();

    public DbSet<Skill> Skills => Set<Skill>();
    public DbSet<SubSkill> SubSkills => Set<SubSkill>();
    public DbSet<Lead> Leads => Set<Lead>();
    public DbSet<LeadMedia> LeadMedias => Set<LeadMedia>();

    public DbSet<LeadSkill> LeadSkills => Set<LeadSkill>();

    public DbSet<LeadSubSkill> LeadSubSkills => Set<LeadSubSkill>();
    public DbSet<LeadSource> LeadSources => Set<LeadSource>();
    public DbSet<Media> Medias => Set<Media>();
    public DbSet<SalesCoordinator> SalesCoordinators => Set<SalesCoordinator>();

    public DbSet<Company> Companies => Set<Company>();

    public DbSet<Opportunity> Opportunity => Set<Opportunity>();

    public DbSet<Account> Account => Set<Account>();

    public DbSet<AccountMedia> AccountMedia => Set<AccountMedia>();
    public DbSet<OpportunityMedia> OpportunityMedia => Set<OpportunityMedia>();

    public DbSet<AccountSalesCoordinator> AccountSalesCoordinator => Set<AccountSalesCoordinator>();
    public DbSet<OpportunitySalesCoordinator> OpportunitySalesCoordinator => Set<OpportunitySalesCoordinator>();

    public DbSet<OpportunitySkill> OpportunitySkill => Set<OpportunitySkill>();
    public DbSet<AccountSkill> AccountSkill => Set<AccountSkill>();

    public DbSet<OpportunitySubSkill> OpportunitySubSkill => Set<OpportunitySubSkill>();
    public DbSet<AccountSubSkill> AccountSubSkills => Set<AccountSubSkill>();
    public DbSet<TechnicalCoordinator> TechnicalCoordinator => Set<TechnicalCoordinator>();
    public DbSet<OpportunityTechnicalCoordinator> OpportunityTechnicalCoordinator => Set<OpportunityTechnicalCoordinator>();
    public DbSet<AccountTechnicalCoordinator> AccountTechnicalCoordinator => Set<AccountTechnicalCoordinator>();
    public DbSet<Country> Country => Set<Country>();
    public DbSet<State> State => Set<State>();
    public DbSet<City> City => Set<City>();
    public DbSet<AccountSource> LeadSource => Set<AccountSource>();
    public DbSet<OpportunitySource> OpportunitySource => Set<OpportunitySource>();
    public DbSet<AccountSource> AccountSource => Set<AccountSource>();

    public DbSet<LeadActivities> LeadActivities => Set<LeadActivities>();

    public DbSet<AccountActivities> AccountActivities => Set<AccountActivities>();
    public DbSet<ActivityMedia> ActivityMedia => Set<ActivityMedia>();

    public DbSet<OpportunityActivities> OpportunityActivities => Set<OpportunityActivities>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema(SchemaNames.Catalog);
    }
}