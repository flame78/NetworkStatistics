using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkStatistics.DAL
{
    using NetworkStatistics.DAL.Repositories;
    using NetworkStatistics.Models;

    public class NetworkStatisticsData : INetworkStatisticsData
    {
        private readonly INetworkStatisticsDbContext context;

        private readonly IDictionary<Type, Object> repositories;

        public NetworkStatisticsData()
            : this(new NetworkStatisticsDbContext())
        {
        }

        public NetworkStatisticsData(INetworkStatisticsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> ApplicationUsers
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Record> Records
        {
            get
            {
                return this.GetRepository<Record>();
            }
        }

        public IRepository<Host> Hosts
        {
            get
            {
                return this.GetRepository<Host>();
            }
        }



        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                //var type = typeof(EFRepository<T>);
                //if (typeOfModel.IsAssignableFrom(typeof(Student)))
                //{
                //    type = typeof(StudentsRepository);
                //}

                var newRepository = Activator.CreateInstance(typeof(EfRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
  
}
}
