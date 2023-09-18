namespace MoSocioAPI.DAC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class initial_migration_create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                {
                    AccountId = c.Int(nullable: false, identity: true),
                    Username = c.String(),
                    Password = c.String(),
                    PasswordConfirmation = c.String(),
                    PartnerId = c.Int(nullable: false),
                    AccessToken = c.String(),
                })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.Partners", t => t.PartnerId)
                .Index(t => t.PartnerId);

            CreateTable(
                "dbo.Partners",
                c => new
                {
                    PartnerId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Birthday = c.DateTime(nullable: false),
                    PartnerNumber = c.String(),
                    DocNumber = c.String(),
                    Photo = c.String(),
                    DateRegistration = c.DateTime(nullable: false),
                    PartnerTypeId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.PartnerId)
                .ForeignKey("dbo.PartnerTypes", t => t.PartnerTypeId)
                .Index(t => t.PartnerTypeId);

            CreateTable(
                "dbo.PartnerTypes",
                c => new
                {
                    PartnerTypeId = c.Int(nullable: false, identity: true),
                    Label = c.String(),
                })
                .PrimaryKey(t => t.PartnerTypeId);

            CreateTable(
                "dbo.Addresses",
                c => new
                {
                    AddressId = c.Int(nullable: false, identity: true),
                    HomeAddress = c.String(),
                    Neighborhood = c.String(),
                    County = c.String(),
                    province = c.String(),
                    PartnerId = c.Int(nullable: false),
                    InstitutionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Institutions", t => t.InstitutionId)
                .ForeignKey("dbo.Partners", t => t.PartnerId)
                .Index(t => t.PartnerId)
                .Index(t => t.InstitutionId);

            CreateTable(
                "dbo.Institutions",
                c => new
                {
                    InstitutionId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    InstitutionTypeId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.InstitutionId)
                .ForeignKey("dbo.InstitutionTypes", t => t.InstitutionTypeId)
                .Index(t => t.InstitutionTypeId);

            CreateTable(
                "dbo.InstitutionTypes",
                c => new
                {
                    InstitutionTypeId = c.Int(nullable: false, identity: true),
                    Label = c.String(),
                })
                .PrimaryKey(t => t.InstitutionTypeId);

            CreateTable(
                "dbo.Cards",
                c => new
                {
                    CardId = c.Int(nullable: false, identity: true),
                    CardNumber = c.String(),
                    IsActived = c.Boolean(nullable: false),
                    WasRaised = c.Boolean(nullable: false),
                    DateCreation = c.DateTime(nullable: false),
                    DateExpiration = c.DateTime(nullable: false),
                    PartnerId = c.Int(nullable: false),
                    InstitutionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.Institutions", t => t.InstitutionId)
                .ForeignKey("dbo.Partners", t => t.PartnerId)
                .Index(t => t.PartnerId)
                .Index(t => t.InstitutionId);

            CreateTable(
                "dbo.Contacts",
                c => new
                {
                    ContactId = c.Int(nullable: false, identity: true),
                    Label = c.String(),
                    ContactTypeId = c.Int(nullable: false),
                    PartnerId = c.Int(nullable: false),
                    InstitutionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId)
                .ForeignKey("dbo.Institutions", t => t.InstitutionId)
                .ForeignKey("dbo.Partners", t => t.PartnerId)
                .Index(t => t.ContactTypeId)
                .Index(t => t.PartnerId)
                .Index(t => t.InstitutionId);

            CreateTable(
                "dbo.ContactTypes",
                c => new
                {
                    ContactTypeId = c.Int(nullable: false, identity: true),
                    Label = c.String(),
                })
                .PrimaryKey(t => t.ContactTypeId);

            CreateTable(
                "dbo.Quotas",
                c => new
                {
                    QuotaId = c.Int(nullable: false, identity: true),
                    Value = c.String(),
                    QuotaTypeId = c.Int(nullable: false),
                    PartnerId = c.Int(nullable: false),
                    InstitutionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.QuotaId)
                .ForeignKey("dbo.Institutions", t => t.InstitutionId)
                .ForeignKey("dbo.Partners", t => t.PartnerId)
                .ForeignKey("dbo.QuotaTypes", t => t.QuotaTypeId)
                .Index(t => t.QuotaTypeId)
                .Index(t => t.PartnerId)
                .Index(t => t.InstitutionId);

            CreateTable(
                "dbo.QuotaTypes",
                c => new
                {
                    QuotaTypeId = c.Int(nullable: false, identity: true),
                    Label = c.String(),
                })
                .PrimaryKey(t => t.QuotaTypeId);

            CreateTable(
                "dbo.Roles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.UserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .ForeignKey("dbo.AppUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Socios",
                c => new
                {
                    SocioId = c.Int(nullable: false, identity: true),
                    NumeroSocio = c.String(),
                    DataRegisto = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.SocioId);

            CreateTable(
                "dbo.AppUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");

            CreateTable(
                "dbo.UserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AppUsers", t => t.UserId)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.UserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AppUsers", t => t.UserId)
                .Index(t => t.UserId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Quotas", "QuotaTypeId", "dbo.QuotaTypes");
            DropForeignKey("dbo.Quotas", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.Quotas", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Contacts", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.Contacts", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Contacts", "ContactTypeId", "dbo.ContactTypes");
            DropForeignKey("dbo.Cards", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.Cards", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Addresses", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.Addresses", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Institutions", "InstitutionTypeId", "dbo.InstitutionTypes");
            DropForeignKey("dbo.Accounts", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.Partners", "PartnerTypeId", "dbo.PartnerTypes");
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.AppUsers", "UserNameIndex");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.Quotas", new[] { "InstitutionId" });
            DropIndex("dbo.Quotas", new[] { "PartnerId" });
            DropIndex("dbo.Quotas", new[] { "QuotaTypeId" });
            DropIndex("dbo.Contacts", new[] { "InstitutionId" });
            DropIndex("dbo.Contacts", new[] { "PartnerId" });
            DropIndex("dbo.Contacts", new[] { "ContactTypeId" });
            DropIndex("dbo.Cards", new[] { "InstitutionId" });
            DropIndex("dbo.Cards", new[] { "PartnerId" });
            DropIndex("dbo.Institutions", new[] { "InstitutionTypeId" });
            DropIndex("dbo.Addresses", new[] { "InstitutionId" });
            DropIndex("dbo.Addresses", new[] { "PartnerId" });
            DropIndex("dbo.Partners", new[] { "PartnerTypeId" });
            DropIndex("dbo.Accounts", new[] { "PartnerId" });
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.AppUsers");
            DropTable("dbo.Socios");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.QuotaTypes");
            DropTable("dbo.Quotas");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.Contacts");
            DropTable("dbo.Cards");
            DropTable("dbo.InstitutionTypes");
            DropTable("dbo.Institutions");
            DropTable("dbo.Addresses");
            DropTable("dbo.PartnerTypes");
            DropTable("dbo.Partners");
            DropTable("dbo.Accounts");
        }
    }
}
