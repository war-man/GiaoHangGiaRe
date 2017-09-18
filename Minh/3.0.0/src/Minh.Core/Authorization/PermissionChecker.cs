using Abp.Authorization;
using Minh.Authorization.Roles;
using Minh.Authorization.Users;

namespace Minh.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
