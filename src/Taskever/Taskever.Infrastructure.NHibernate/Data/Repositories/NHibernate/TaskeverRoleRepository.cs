using Abp.Domain.Repositories.NHibernate;
using Abp.Modules.Core.Data.Repositories.NHibernate;
using Taskever.Security.Roles;
using Taskever.Security.Users;

namespace Taskever.Data.Repositories.NHibernate
{
    public class TaskeverRoleRepository : NhRepositoryBase<TaskeverRole>, ITaskeverRoleRepository
    {
        
    }
}