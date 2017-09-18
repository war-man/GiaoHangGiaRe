using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Minh.EntityFramework;

namespace Minh.Migrator
{
    [DependsOn(typeof(MinhDataModule))]
    public class MinhMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<MinhDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}