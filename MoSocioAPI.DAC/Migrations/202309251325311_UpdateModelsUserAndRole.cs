namespace MoSocioAPI.DAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModelsUserAndRole : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.Quotas", "QuotaTypeId", "dbo.QuotaTypes");
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.AppUsers", "UserNameIndex");
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            RenameColumn(table: "dbo.Cards", name: "CardId", newName: "Id");
            RenameColumn(table: "dbo.Institutions", name: "InstitutionId", newName: "Id");
            RenameColumn(table: "dbo.InstitutionTypes", name: "InstitutionTypeId", newName: "Id");
            RenameColumn(table: "dbo.InstitutionTypes", name: "Label", newName: "Name");
            RenameColumn(table: "dbo.Provinces", name: "ProvinceId", newName: "Id");
            RenameColumn(table: "dbo.Partners", name: "PartnerId", newName: "Id");
            RenameColumn(table: "dbo.PartnerTypes", name: "PartnerTypeId", newName: "Id");
            RenameColumn(table: "dbo.Quotas", name: "QuotaId", newName: "Id");
            RenameColumn(table: "dbo.QuotaTypes", name: "QuotaTypeId", newName: "Id");
            RenameColumn(table: "dbo.Socios", name: "SocioId", newName: "Id");
            DropPrimaryKey("dbo.Roles");
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 80),
                        Email = c.String(nullable: false, maxLength: 200),
                        PhoneNumber = c.String(maxLength: 20),
                        UserName = c.String(),
                        Password = c.String(nullable: false, maxLength: 200),
                        InstitutionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Institutions", t => t.InstitutionId, cascadeDelete: true)
                .Index(t => t.InstitutionId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            AlterColumn("dbo.Cards", "CardNumber", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Institutions", "Name", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Institutions", "Telefone1", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Institutions", "Telefone2", c => c.String(maxLength: 20));
            AlterColumn("dbo.Institutions", "WhatsApp", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Institutions", "Email", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Institutions", "HomeAddress", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.InstitutionTypes", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Provinces", "Name", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Partners", "Name", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Partners", "DocNumber", c => c.String(maxLength: 30));
            AlterColumn("dbo.Partners", "Photo", c => c.String(maxLength: 200));
            AlterColumn("dbo.Partners", "DateRegistration", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Partners", "Telefone1", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Partners", "Telefone2", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Partners", "WhatsApp", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Partners", "Email", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Partners", "HomeAddress", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.PartnerTypes", "Label", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Quotas", "Value", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Quotas", "DateCreation", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.QuotaTypes", "Label", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Roles", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Socios", "NumeroSocio", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Socios", "DataRegisto", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddPrimaryKey("dbo.Roles", "Id");
            AddForeignKey("dbo.Quotas", "QuotaTypeId", "dbo.QuotaTypes", "Id", cascadeDelete: true);
            DropTable("dbo.UserRoles");
            DropTable("dbo.AppUsers");
            DropTable("dbo.UserClaims");
            DropTable("dbo.UserLogins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            DropForeignKey("dbo.Quotas", "QuotaTypeId", "dbo.QuotaTypes");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "InstitutionId", "dbo.Institutions");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "InstitutionId" });
            DropPrimaryKey("dbo.Roles");
            AlterColumn("dbo.Socios", "DataRegisto", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Socios", "NumeroSocio", c => c.String());
            AlterColumn("dbo.Roles", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Roles", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.QuotaTypes", "Label", c => c.String());
            AlterColumn("dbo.Quotas", "DateCreation", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Quotas", "Value", c => c.String());
            AlterColumn("dbo.PartnerTypes", "Label", c => c.String());
            AlterColumn("dbo.Partners", "HomeAddress", c => c.String());
            AlterColumn("dbo.Partners", "Email", c => c.String());
            AlterColumn("dbo.Partners", "WhatsApp", c => c.String(nullable: false));
            AlterColumn("dbo.Partners", "Telefone2", c => c.String());
            AlterColumn("dbo.Partners", "Telefone1", c => c.String(nullable: false));
            AlterColumn("dbo.Partners", "DateRegistration", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Partners", "Photo", c => c.String());
            AlterColumn("dbo.Partners", "DocNumber", c => c.String());
            AlterColumn("dbo.Partners", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Provinces", "Name", c => c.String());
            AlterColumn("dbo.InstitutionTypes", "Name", c => c.String());
            AlterColumn("dbo.Institutions", "HomeAddress", c => c.String());
            AlterColumn("dbo.Institutions", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Institutions", "WhatsApp", c => c.String());
            AlterColumn("dbo.Institutions", "Telefone2", c => c.String(nullable: false));
            AlterColumn("dbo.Institutions", "Telefone1", c => c.String(nullable: false));
            AlterColumn("dbo.Institutions", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Cards", "CardNumber", c => c.String());
            DropTable("dbo.UserRole");
            DropTable("dbo.Users");
            AddPrimaryKey("dbo.Roles", "Id");
            RenameColumn(table: "dbo.Socios", name: "Id", newName: "SocioId");
            RenameColumn(table: "dbo.QuotaTypes", name: "Id", newName: "QuotaTypeId");
            RenameColumn(table: "dbo.Quotas", name: "Id", newName: "QuotaId");
            RenameColumn(table: "dbo.PartnerTypes", name: "Id", newName: "PartnerTypeId");
            RenameColumn(table: "dbo.Partners", name: "Id", newName: "PartnerId");
            RenameColumn(table: "dbo.Provinces", name: "Id", newName: "ProvinceId");
            RenameColumn(table: "dbo.InstitutionTypes", name: "Name", newName: "Label");
            RenameColumn(table: "dbo.InstitutionTypes", name: "Id", newName: "InstitutionTypeId");
            RenameColumn(table: "dbo.Institutions", name: "Id", newName: "InstitutionId");
            RenameColumn(table: "dbo.Cards", name: "Id", newName: "CardId");
            CreateIndex("dbo.UserLogins", "UserId");
            CreateIndex("dbo.UserClaims", "UserId");
            CreateIndex("dbo.AppUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.UserRoles", "RoleId");
            CreateIndex("dbo.UserRoles", "UserId");
            CreateIndex("dbo.Roles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.Quotas", "QuotaTypeId", "dbo.QuotaTypes", "QuotaTypeId");
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.UserLogins", "UserId", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.UserClaims", "UserId", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles", "Id");
        }
    }
}
