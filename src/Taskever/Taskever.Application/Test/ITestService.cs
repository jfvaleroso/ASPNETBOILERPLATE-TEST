using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Test.Dto;
using Abp.Users.Dto;
using Taskever.Security.Roles;

namespace Abp.Test
{
    public interface ITestService: IApplicationService
    {
        IList<RoleDto> Test();
        void Create(TaskeverRole taskeverRole);
    }
}
