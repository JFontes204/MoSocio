namespace MoSocioAPI.DAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactoracao_do_modelo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "PartnerId", "dbo.Partners");
            DropForeignKey("dbo.AddressesInstitution", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.ContactsInstitution", "ContactTypeId", "dbo.ContactTypes");
            DropForeignKey("dbo.ContactsInstitution", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.InstitutionPartners", "Institution_InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.InstitutionPartners", "Partner_PartnerId", "dbo.Partners");
            DropForeignKey("dbo.Contacts", "ContactTypeId", "dbo.ContactTypes");
            DropForeignKey("dbo.Contacts", "PartnerId", "dbo.Partners");
            DropIndex("dbo.Addresses", new[] { "PartnerId" });
            DropIndex("dbo.AddressesInstitution", new[] { "InstitutionId" });
            DropIndex("dbo.ContactsInstitution", new[] { "ContactTypeId" });
            DropIndex("dbo.ContactsInstitution", new[] { "InstitutionId" });
            DropIndex("dbo.Contacts", new[] { "ContactTypeId" });
            DropIndex("dbo.Contacts", new[] { "PartnerId" });
            DropIndex("dbo.InstitutionPartners", new[] { "Institution_InstitutionId" });
            DropIndex("dbo.InstitutionPartners", new[] { "Partner_PartnerId" });
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        ProvinceId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ProvinceId);
            
            AddColumn("dbo.Partners", "Telefone1", c => c.String(nullable: false));
            AddColumn("dbo.Partners", "Telefone2", c => c.String());
            AddColumn("dbo.Partners", "WhatsApp", c => c.String(nullable: false));
            AddColumn("dbo.Partners", "Email", c => c.String());
            AddColumn("dbo.Partners", "HomeAddress", c => c.String());
            AddColumn("dbo.Partners", "ProvinceId", c => c.Int(nullable: false));
            AddColumn("dbo.Partners", "InstitutionId", c => c.Int(nullable: false));
            AddColumn("dbo.Institutions", "Telefone1", c => c.String(nullable: false));
            AddColumn("dbo.Institutions", "Telefone2", c => c.String(nullable: false));
            AddColumn("dbo.Institutions", "WhatsApp", c => c.String());
            AddColumn("dbo.Institutions", "Email", c => c.String(nullable: false));
            AddColumn("dbo.Institutions", "HomeAddress", c => c.String());
            AddColumn("dbo.Institutions", "ProvinceId", c => c.Int(nullable: false));
            AddColumn("dbo.Quotas", "DateCreation", c => c.DateTime(nullable: false));
            AddColumn("dbo.QuotaTypes", "InstitutionId", c => c.Int(nullable: false));
            AddColumn("dbo.PartnerTypes", "InstitutionId", c => c.Int(nullable: false));
            AlterColumn("dbo.Partners", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Institutions", "Name", c => c.String(nullable: false));
            CreateIndex("dbo.Institutions", "Telefone1", unique: true, name: "TelefoneIndex");
            CreateIndex("dbo.Institutions", "Email", unique: true, name: "E-mailIndex");
            CreateIndex("dbo.Institutions", "ProvinceId");
            CreateIndex("dbo.Partners", "Telefone1", unique: true, name: "TelefoneIndex");
            CreateIndex("dbo.Partners", "Email", unique: true, name: "E-mailIndex");
            CreateIndex("dbo.Partners", "ProvinceId");
            CreateIndex("dbo.Partners", "InstitutionId");
            CreateIndex("dbo.PartnerTypes", "InstitutionId");
            CreateIndex("dbo.QuotaTypes", "InstitutionId");
            AddForeignKey("dbo.Institutions", "ProvinceId", "dbo.Provinces", "ProvinceId");
            AddForeignKey("dbo.Partners", "InstitutionId", "dbo.Institutions", "InstitutionId");
            AddForeignKey("dbo.PartnerTypes", "InstitutionId", "dbo.Institutions", "InstitutionId");
            AddForeignKey("dbo.Partners", "ProvinceId", "dbo.Provinces", "ProvinceId");
            AddForeignKey("dbo.QuotaTypes", "InstitutionId", "dbo.Institutions", "InstitutionId");
            DropTable("dbo.Addresses");
            DropTable("dbo.AddressesInstitution");
            DropTable("dbo.ContactsInstitution");
            DropTable("dbo.ContactTypes");
            DropTable("dbo.Contacts");
            DropTable("dbo.InstitutionPartners");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InstitutionPartners",
                c => new
                    {
                        Institution_InstitutionId = c.Int(nullable: false),
                        Partner_PartnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Institution_InstitutionId, t.Partner_PartnerId });
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        ContactTypeId = c.Int(nullable: false),
                        PartnerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.ContactTypes",
                c => new
                    {
                        ContactTypeId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                    })
                .PrimaryKey(t => t.ContactTypeId);
            
            CreateTable(
                "dbo.ContactsInstitution",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        Label = c.String(),
                        ContactTypeId = c.Int(nullable: false),
                        InstitutionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId);
            
            CreateTable(
                "dbo.AddressesInstitution",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        HomeAddress = c.String(),
                        Neighborhood = c.String(),
                        County = c.String(),
                        province = c.String(),
                        InstitutionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId);
            
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
                    })
                .PrimaryKey(t => t.AddressId);
            
            DropForeignKey("dbo.QuotaTypes", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Partners", "ProvinceId", "dbo.Provinces");
            DropForeignKey("dbo.PartnerTypes", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Partners", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Institutions", "ProvinceId", "dbo.Provinces");
            DropIndex("dbo.QuotaTypes", new[] { "InstitutionId" });
            DropIndex("dbo.PartnerTypes", new[] { "InstitutionId" });
            DropIndex("dbo.Partners", new[] { "InstitutionId" });
            DropIndex("dbo.Partners", new[] { "ProvinceId" });
            DropIndex("dbo.Partners", "E-mailIndex");
            DropIndex("dbo.Partners", "TelefoneIndex");
            DropIndex("dbo.Institutions", new[] { "ProvinceId" });
            DropIndex("dbo.Institutions", "E-mailIndex");
            DropIndex("dbo.Institutions", "TelefoneIndex");
            AlterColumn("dbo.Institutions", "Name", c => c.String());
            AlterColumn("dbo.Partners", "Name", c => c.String());
            DropColumn("dbo.PartnerTypes", "InstitutionId");
            DropColumn("dbo.QuotaTypes", "InstitutionId");
            DropColumn("dbo.Quotas", "DateCreation");
            DropColumn("dbo.Institutions", "ProvinceId");
            DropColumn("dbo.Institutions", "HomeAddress");
            DropColumn("dbo.Institutions", "Email");
            DropColumn("dbo.Institutions", "WhatsApp");
            DropColumn("dbo.Institutions", "Telefone2");
            DropColumn("dbo.Institutions", "Telefone1");
            DropColumn("dbo.Partners", "InstitutionId");
            DropColumn("dbo.Partners", "ProvinceId");
            DropColumn("dbo.Partners", "HomeAddress");
            DropColumn("dbo.Partners", "Email");
            DropColumn("dbo.Partners", "WhatsApp");
            DropColumn("dbo.Partners", "Telefone2");
            DropColumn("dbo.Partners", "Telefone1");
            DropTable("dbo.Provinces");
            CreateIndex("dbo.InstitutionPartners", "Partner_PartnerId");
            CreateIndex("dbo.InstitutionPartners", "Institution_InstitutionId");
            CreateIndex("dbo.Contacts", "PartnerId");
            CreateIndex("dbo.Contacts", "ContactTypeId");
            CreateIndex("dbo.ContactsInstitution", "InstitutionId");
            CreateIndex("dbo.ContactsInstitution", "ContactTypeId");
            CreateIndex("dbo.AddressesInstitution", "InstitutionId");
            CreateIndex("dbo.Addresses", "PartnerId");
            AddForeignKey("dbo.Contacts", "PartnerId", "dbo.Partners", "PartnerId");
            AddForeignKey("dbo.Contacts", "ContactTypeId", "dbo.ContactTypes", "ContactTypeId");
            AddForeignKey("dbo.InstitutionPartners", "Partner_PartnerId", "dbo.Partners", "PartnerId", cascadeDelete: true);
            AddForeignKey("dbo.InstitutionPartners", "Institution_InstitutionId", "dbo.Institutions", "InstitutionId", cascadeDelete: true);
            AddForeignKey("dbo.ContactsInstitution", "InstitutionId", "dbo.Institutions", "InstitutionId");
            AddForeignKey("dbo.ContactsInstitution", "ContactTypeId", "dbo.ContactTypes", "ContactTypeId");
            AddForeignKey("dbo.AddressesInstitution", "InstitutionId", "dbo.Institutions", "InstitutionId");
            AddForeignKey("dbo.Addresses", "PartnerId", "dbo.Partners", "PartnerId");
        }
    }
}
