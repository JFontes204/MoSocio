namespace MoSocioAPI.DAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refatorandoModeloAddUserERole : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Roles", newName: "Role");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.AppUsers");
            DropForeignKey("dbo.Cards", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Cards", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.Institutions", "InstitutionTypeId", "dbo.InstitutionTypes");
            DropForeignKey("dbo.Institutions", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Partners", "PartnerTypeId", "dbo.PartnerTypes");
            DropForeignKey("dbo.Partners", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.PartnerTypes", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Quotas", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Quotas", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.Quotas", "QuotaTypeId", "dbo.QuotaTypes");
            DropForeignKey("dbo.QuotaTypes", "InstitutionId", "dbo.Institutions");
            DropIndex("dbo.Role", "RoleNameIndex");
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.AppUsers", "UserNameIndex");
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropPrimaryKey("dbo.Role");
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 80),
                        Email = c.String(nullable: false, maxLength: 200),
                        PhoneNumber = c.String(maxLength: 20),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        InstitutionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Institutions", t => t.InstitutionId, cascadeDelete: true)
                .Index(t => t.InstitutionId);
            
            AddColumn("dbo.Role", "User_Id", c => c.Int());
            AlterColumn("dbo.Institutions", "Telefone2", c => c.String());
            AlterColumn("dbo.Partners", "WhatsApp", c => c.String());
            AlterColumn("dbo.Role", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Role", "Name", c => c.String(nullable: false, maxLength: 40));
            AddPrimaryKey("dbo.Role", "Id");
            CreateIndex("dbo.Role", "User_Id");
            AddForeignKey("dbo.Role", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Cards", "InstitutionId", "dbo.Institutions", "InstitutionId", cascadeDelete: true);
            AddForeignKey("dbo.Cards", "PartnerId", "dbo.Partners", "PartnerId", cascadeDelete: true);
            AddForeignKey("dbo.Institutions", "InstitutionTypeId", "dbo.InstitutionTypes", "InstitutionTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Institutions", "ProvinceId", "dbo.Provinces", "ProvinceId", cascadeDelete: true);
            AddForeignKey("dbo.Partners", "PartnerTypeId", "dbo.PartnerTypes", "PartnerTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Partners", "ProvinceId", "dbo.Provinces", "ProvinceId", cascadeDelete: true);
            AddForeignKey("dbo.PartnerTypes", "InstitutionId", "dbo.Institutions", "InstitutionId", cascadeDelete: true);
            AddForeignKey("dbo.Quotas", "InstitutionId", "dbo.Institutions", "InstitutionId", cascadeDelete: true);
            AddForeignKey("dbo.Quotas", "PartnerId", "dbo.Partners", "PartnerId", cascadeDelete: true);
            AddForeignKey("dbo.Quotas", "QuotaTypeId", "dbo.QuotaTypes", "QuotaTypeId", cascadeDelete: true);
            AddForeignKey("dbo.QuotaTypes", "InstitutionId", "dbo.Institutions", "InstitutionId", cascadeDelete: true);
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
            
            DropForeignKey("dbo.QuotaTypes", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Quotas", "QuotaTypeId", "dbo.QuotaTypes");
            DropForeignKey("dbo.Quotas", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.Quotas", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.PartnerTypes", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Partners", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Partners", "PartnerTypeId", "dbo.PartnerTypes");
            DropForeignKey("dbo.Institutions", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.Institutions", "InstitutionTypeId", "dbo.InstitutionTypes");
            DropForeignKey("dbo.Cards", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.Cards", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Role", "User_Id", "dbo.User");
            DropForeignKey("dbo.User", "InstitutionId", "dbo.Institutions");
            DropIndex("dbo.User", new[] { "InstitutionId" });
            DropIndex("dbo.Role", new[] { "User_Id" });
            DropPrimaryKey("dbo.Role");
            AlterColumn("dbo.Role", "Name", c => c.String(nullable: false, maxLength: 256));
            AlterColumn("dbo.Role", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Partners", "WhatsApp", c => c.String(nullable: false));
            AlterColumn("dbo.Institutions", "Telefone2", c => c.String(nullable: false));
            DropColumn("dbo.Role", "User_Id");
            DropTable("dbo.User");
            AddPrimaryKey("dbo.Role", "Id");
            CreateIndex("dbo.UserLogins", "UserId");
            CreateIndex("dbo.UserClaims", "UserId");
            CreateIndex("dbo.AppUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.UserRoles", "RoleId");
            CreateIndex("dbo.UserRoles", "UserId");
            CreateIndex("dbo.Role", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.QuotaTypes", "InstitutionId", "dbo.Institutions", "InstitutionId");
            AddForeignKey("dbo.Quotas", "QuotaTypeId", "dbo.QuotaTypes", "QuotaTypeId");
            AddForeignKey("dbo.Quotas", "PartnerId", "dbo.Partners", "PartnerId");
            AddForeignKey("dbo.Quotas", "InstitutionId", "dbo.Institutions", "InstitutionId");
            AddForeignKey("dbo.PartnerTypes", "InstitutionId", "dbo.Institutions", "InstitutionId");
            AddForeignKey("dbo.Partners", "ProvinceId", "dbo.Provinces", "ProvinceId");
            AddForeignKey("dbo.Partners", "PartnerTypeId", "dbo.PartnerTypes", "PartnerTypeId");
            AddForeignKey("dbo.Institutions", "ProvinceId", "dbo.Provinces", "ProvinceId");
            AddForeignKey("dbo.Institutions", "InstitutionTypeId", "dbo.InstitutionTypes", "InstitutionTypeId");
            AddForeignKey("dbo.Cards", "PartnerId", "dbo.Partners", "PartnerId");
            AddForeignKey("dbo.Cards", "InstitutionId", "dbo.Institutions", "InstitutionId");
            AddForeignKey("dbo.UserRoles", "UserId", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.UserLogins", "UserId", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.UserClaims", "UserId", "dbo.AppUsers", "Id");
            AddForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles", "Id");
            RenameTable(name: "dbo.Role", newName: "Roles");
        }
    }
}
