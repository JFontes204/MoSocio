namespace MoSocioAPI.DAC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class create_contactInstitution_and_addressInstitution : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.Contacts", "InstitutionId", "dbo.Institutions");
            DropIndex("dbo.Addresses", new[] { "InstitutionId" });
            DropIndex("dbo.Contacts", new[] { "InstitutionId" });
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
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Institutions", t => t.InstitutionId)
                .Index(t => t.InstitutionId);

            CreateTable(
                "dbo.ContactsInstitution",
                c => new
                {
                    ContactId = c.Int(nullable: false, identity: true),
                    Label = c.String(),
                    ContactTypeId = c.Int(nullable: false),
                    InstitutionId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.ContactId)
                .ForeignKey("dbo.ContactTypes", t => t.ContactTypeId)
                .ForeignKey("dbo.Institutions", t => t.InstitutionId)
                .Index(t => t.ContactTypeId)
                .Index(t => t.InstitutionId);

            DropColumn("dbo.Addresses", "InstitutionId");
            DropColumn("dbo.Contacts", "InstitutionId");
        }

        public override void Down()
        {
            AddColumn("dbo.Contacts", "InstitutionId", c => c.Int(nullable: false));
            AddColumn("dbo.Addresses", "InstitutionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ContactsInstitution", "InstitutionId", "dbo.Institutions");
            DropForeignKey("dbo.ContactsInstitution", "ContactTypeId", "dbo.ContactTypes");
            DropForeignKey("dbo.AddressesInstitution", "InstitutionId", "dbo.Institutions");
            DropIndex("dbo.ContactsInstitution", new[] { "InstitutionId" });
            DropIndex("dbo.ContactsInstitution", new[] { "ContactTypeId" });
            DropIndex("dbo.AddressesInstitution", new[] { "InstitutionId" });
            DropTable("dbo.ContactsInstitution");
            DropTable("dbo.AddressesInstitution");
            CreateIndex("dbo.Contacts", "InstitutionId");
            CreateIndex("dbo.Addresses", "InstitutionId");
            AddForeignKey("dbo.Contacts", "InstitutionId", "dbo.Institutions", "InstitutionId");
            AddForeignKey("dbo.Addresses", "InstitutionId", "dbo.Institutions", "InstitutionId");
        }
    }
}
