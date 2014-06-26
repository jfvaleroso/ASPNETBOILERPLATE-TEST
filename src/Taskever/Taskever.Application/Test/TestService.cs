using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Test.Dto;
using Abp.Users.Dto;
using Taskever.Security.Roles;
using Taskever.Security.Users;
using Abp.Mapping;

namespace Abp.Test
{
    public class TestService: ITestService
    {

        private readonly ITaskeverUserRepository _taskeverUserRepository;
        private readonly ITaskeverRoleRepository _taskeverRoleRepository;
        public TestService(ITaskeverUserRepository taskeverUserRepository, ITaskeverRoleRepository taskeverRoleRepository)
        {
            _taskeverUserRepository = taskeverUserRepository;
            _taskeverRoleRepository = taskeverRoleRepository;
        }
        public IList<RoleDto> Test()
        {
            return _taskeverRoleRepository.GetAllList().MapIList<TaskeverRole, RoleDto>();
        }

        public void Create(TaskeverRole taskeverRole)
        {
            _taskeverRoleRepository.Insert(taskeverRole);
        }
    }
}
