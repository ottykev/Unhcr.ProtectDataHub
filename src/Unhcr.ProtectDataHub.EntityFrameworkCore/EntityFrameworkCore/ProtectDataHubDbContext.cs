using Microsoft.EntityFrameworkCore;
using Unhcr.ProtectDataHub.Countries;
using Unhcr.ProtectDataHub.Persons;
using Unhcr.ProtectDataHub.Regions;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Unhcr.ProtectDataHub.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class ProtectDataHubDbContext :
    AbpDbContext<ProtectDataHubDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion
    public DbSet<Region> Regions { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Person> Persons { get; set; }

    public ProtectDataHubDbContext(DbContextOptions<ProtectDataHubDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */
        builder.Entity<Region>(b =>
        {
            b.ToTable(ProtectDataHubConsts.DbTablePrefix + "Regions", ProtectDataHubConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(RegionConsts.MaxNameLength);
            b.HasIndex(x => x.Name);
        });
        builder.Entity<Country>(b =>
        {
            b.ToTable(ProtectDataHubConsts.DbTablePrefix + "Countries", ProtectDataHubConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.Name).IsRequired().HasMaxLength(CountryConsts.MaxNameLength);
            b.Property(x => x.Code).IsRequired().HasMaxLength(CountryConsts.MaxCodeLength);
            b.HasIndex(x => x.Name);
            b.HasOne<Region>().WithMany().HasForeignKey(x => x.RegionId);
        });
        builder.Entity<Person>(b =>
        {
            b.ToTable(ProtectDataHubConsts.DbTablePrefix + "Persons", ProtectDataHubConsts.DbSchema);
            b.ConfigureByConvention(); //auto configure for the base class props
            b.Property(x => x.FullName).IsRequired().HasMaxLength(PersonConsts.MaxFullNameLength);
            b.Property(x => x.Email).HasMaxLength(PersonConsts.MaxEmailLength);
            b.Property(x => x.PhoneNumber).HasMaxLength(PersonConsts.MaxPhoneNumberLength);
            b.Property(x => x.DutyStation).HasMaxLength(PersonConsts.MaxDutyStationLength);
            b.Property(x => x.OrganizationName).HasMaxLength(PersonConsts.MaxOrganizationNameLength);
            b.Property(x => x.Aor);
            b.Property(x => x.LevelofCordination);
            b.Property(x => x.DutyStation);
            b.Property(x => x.WorkingfromDutyStation);
            b.Property(x => x.Organization_Type);
            b.Property(x => x.Position);
            b.Property(x => x.Staff);
            b.Property(x => x.DoubleHatting);
            b.Property(x => x.StaffGrade);
            b.Property(x => x.ContractType);
            b.Property(p => p.StartDate).HasColumnType("date");
            b.Property(p => p.EndDate).HasColumnType("date");
            b.Property(x => x.IsActive);
            b.HasIndex(x => x.FullName);
            b.HasOne<Country>().WithMany().HasForeignKey(x => x.CountryId);
        });
        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(ProtectDataHubConsts.DbTablePrefix + "YourEntities", ProtectDataHubConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});
    }
}
