namespace MoSocioAPI.DAC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class refinamento_das_entidades : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "PartnerId", "dbo.Partners");
            DropIndex("dbo.Accounts", new[] { "PartnerId" });
            CreateTable(
                "dbo.InstitutionPartners",
                c => new
                {
                    Institution_InstitutionId = c.Int(nullable: false),
                    Partner_PartnerId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Institution_InstitutionId, t.Partner_PartnerId })
                .ForeignKey("dbo.Institutions", t => t.Institution_InstitutionId, cascadeDelete: true)
                .ForeignKey("dbo.Partners", t => t.Partner_PartnerId, cascadeDelete: true)
                .Index(t => t.Institution_InstitutionId)
                .Index(t => t.Partner_PartnerId);

            DropTable("dbo.Accounts");
        }

        public override void Down()
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
                .PrimaryKey(t => t.AccountId);

            DropForeignKey("dbo.InstitutionPartners", "Partner_PartnerId", "dbo.Partners");
            DropForeignKey("dbo.InstitutionPartners", "Institution_InstitutionId", "dbo.Institutions");
            DropIndex("dbo.InstitutionPartners", new[] { "Partner_PartnerId" });
            DropIndex("dbo.InstitutionPartners", new[] { "Institution_InstitutionId" });
            DropTable("dbo.InstitutionPartners");
            CreateIndex("dbo.Accounts", "PartnerId");
            AddForeignKey("dbo.Accounts", "PartnerId", "dbo.Partners", "PartnerId");
        }
    }
}
