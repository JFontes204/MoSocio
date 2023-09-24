using System.Data.Entity.Migrations;

namespace MoSocioAPI.DAC.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<MoSocioAPIDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MoSocioAPIDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
