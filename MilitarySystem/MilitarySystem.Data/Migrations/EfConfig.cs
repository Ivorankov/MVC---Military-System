namespace MilitarySystem.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public class EfConfig : DbMigrationsConfiguration<MilitarySystemContext>
    {
        public EfConfig()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
    }
}
