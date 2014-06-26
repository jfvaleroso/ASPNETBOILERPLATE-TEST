using Abp.Security.Roles;
using Abp.Security.Users;
using Taskever.Security.Users;

namespace Abp.Test.Dto
{
    public static class RolesDtosMapper
    {
        public static void Map()
        {


            AutoMapper.Mapper.CreateMap<AbpRole, RoleDto>().ReverseMap();

        }
    }
}
