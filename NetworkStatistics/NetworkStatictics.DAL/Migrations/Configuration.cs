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
            if (!context.Users.Any(u => u.UserName == "admin@firm.bg"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@firm.bg" };

                manager.Create(user, DefaultPassword);
                manager.AddToRole(user.Id, GlobalConstants.AdministratorRole);
            }

            if (!context.Users.Any(u => u.UserName == "headquarter_logger@firm.bg"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "headquarter_logger@firm.bg" };

                manager.Create(user,DefaultPassword);
                manager.AddToRole(user.Id, GlobalConstants.LoggerRole);
            }

            if (!context.Users.Any(u => u.UserName == "boss@firm.bg"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "boss@firm.bg" };

                manager.Create(user,DefaultPassword);
                manager.AddToRole(user.Id, GlobalConstants.BossRole);
            }

            if (!context.Users.Any(u => u.UserName == "1@1.bg"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "1@1.bg" };

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
