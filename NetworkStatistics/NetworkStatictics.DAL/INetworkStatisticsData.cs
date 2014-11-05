namespace NetworkStatistics.DAL
{
    using NetworkStatistics.DAL.Repositories;
    using NetworkStatistics.Models;

    public interface INetworkStatisticsData
    {
        IRepository<ApplicationUser> ApplicationUsers { get; }

        IRepository<User> Users { get; }

        IRepository<Host> Hosts { get; }

        IRepository<Record> Records { get; }

        void SaveChanges();
    }
}
