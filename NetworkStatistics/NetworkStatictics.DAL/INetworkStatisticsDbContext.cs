namespace NetworkStatistics.DAL
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using NetworkStatistics.Models;

    public interface INetworkStatisticsDbContext
    {
        IDbSet<Consumer> Consumers { get; set; }

        IDbSet<Record> Records { get; set; }

        IDbSet<Host> Hosts { get; set; }

        int SaveChanges();

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;
    }
}
