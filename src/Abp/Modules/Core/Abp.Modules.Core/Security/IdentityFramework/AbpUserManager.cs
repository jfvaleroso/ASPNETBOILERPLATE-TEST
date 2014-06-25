using Abp.Dependency;
using Abp.Security.Users;
using Microsoft.AspNet.Identity;

namespace Abp.Security.IdentityFramework
{
    public class AbpUserManager : UserManager<AbpUser, int>, ITransientDependency
    {
        public AbpUserManager(AbpUserStore store)
            : base(store)
        {

        }
    }
}