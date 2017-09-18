using System.Linq;
using Minh.EntityFramework;
using Minh.MultiTenancy;

namespace Minh.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly MinhDbContext _context;

        public DefaultTenantCreator(MinhDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
