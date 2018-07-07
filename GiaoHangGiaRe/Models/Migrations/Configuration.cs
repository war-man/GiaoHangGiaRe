namespace Models.Migrations
{
    using EntityModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.EntityModel.GiaoHangGiaReDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.EntityModel.GiaoHangGiaReDbContext context)
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
            context.Provinces.AddOrUpdate(
                p => p.Province_Id,
                    new Province { Province_Name = "Hà nội", Province_Code = "1"
                });
            context.Districts.AddOrUpdate(
               p => p.District_Id,
                   new District {
                       District_Name = "Hoàng Mai",
                       District_Code = "1"
                   });
            context.Communes.AddOrUpdate(
                p => p.Commune_Id,
               new Commune
               {
                   Commune_Name = "Định công",
                   Commune_Code = "1"
               });
        }
    }
}
