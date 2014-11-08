namespace NetworkStatistics.DAL.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using NetworkStatistics.Models;
    using NetworkStatistics.Resources;

    internal sealed class Configuration : DbMigrationsConfiguration<NetworkStatisticsDbContext>
    {
        
        private const string DefaultPassword = "123456";

        private const string SeedAdmin = "admin@firm.bg";

        private const string SeedBoss = "boss@firm.bg";

        private const string SeedLogger = "headquarter_logger@firm.bg";

        private const string SeedUser = "1@1.bg";



        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(NetworkStatisticsDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            SeedRoles(context);

            SeedUsers(context);
        }

        private static void SeedUsers(NetworkStatisticsDbContext context)
        {
            if (!context.Users.Any(u => u.UserName == SeedAdmin))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = SeedAdmin, Email = SeedAdmin };

                manager.Create(user, DefaultPassword);
                manager.AddToRole(user.Id, GlobalConstants.AdministratorRole);
            }

            if (!context.Users.Any(u => u.UserName == SeedLogger))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName =SeedLogger, Email = SeedLogger};

                manager.Create(user,DefaultPassword);
                manager.AddToRole(user.Id, GlobalConstants.LoggerRole);
            }

            if (!context.Users.Any(u => u.UserName == SeedBoss))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = SeedBoss, Email = SeedBoss};

                manager.Create(user,DefaultPassword);
                manager.AddToRole(user.Id, GlobalConstants.BossRole);
            }

            if (!context.Users.Any(u => u.UserName == SeedUser))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = SeedUser, Email = SeedUser};

                manager.Create(user, DefaultPassword);
            }
        }

        private static void SeedRoles(NetworkStatisticsDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == GlobalConstants.AdministratorRole))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = GlobalConstants.AdministratorRole };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == GlobalConstants.LoggerRole))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = GlobalConstants.LoggerRole };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == GlobalConstants.BossRole))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = GlobalConstants.BossRole };

                manager.Create(role);
            }
        }
    }
}
