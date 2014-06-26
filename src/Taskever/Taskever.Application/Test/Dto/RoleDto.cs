using Abp.Application.Services.Dto;

namespace Abp.Test.Dto
{
    /// <summary>
    /// Simple User DTO class.
    /// </summary>
    public class RoleDto : EntityDto
    {
        public virtual string Name { get; set; }

        /// <summary>
        /// Display name of this role.
        /// </summary>
        public virtual string DisplayName { get; set; }
    }
}
