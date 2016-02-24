namespace MilitarySystem.Web
{
    using System.Data.Entity;

    using MilitarySystem.Data;
    using MilitarySystem.Data.Migrations;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MilitarySystemContext, EfConfig>());
            //MilitarySystemContext.Create().Database.Initialize(true);
        }
    }
}