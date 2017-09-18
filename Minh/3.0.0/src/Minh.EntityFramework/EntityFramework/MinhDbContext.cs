using System.Data.Common;
using Abp.Zero.EntityFramework;
using Minh.Authorization.Roles;
using Minh.Authorization.Users;
using Minh.MultiTenancy;

namespace Minh.EntityFramework
{
    public class MinhDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public MinhDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in MinhDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of MinhDbContext since ABP automatically handles it.
         */
        public MinhDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public MinhDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public MinhDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
