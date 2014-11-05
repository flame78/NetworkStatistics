namespace NetworkStatistics.DAL
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using NetworkStatistics.DAL.Migrations;
    using NetworkStatistics.Models;

    public class NetworkStatisticsDbContext : IdentityDbContext<ApplicationUser>, INetworkStatisticsDbContext
    {
        public NetworkStatisticsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NetworkStatisticsDbContext, Configuration>());
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Record> Records { get; set; }

        public IDbSet<Host> Hosts { get; set; }

        public static NetworkStatisticsDbContext Create()
        {
            return new NetworkStatisticsDbContext();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }


    }
}
