﻿using Abp.Localization;

namespace Abp.Application.Authorization.Permissions
{
    /// <summary>
    /// Represents a permission.
    /// A permission is used to restrict functionalities of the application from unauthorized users.
    /// </summary>
    public class PermissionDefinition
    {
        /// <summary>
        /// Unique name of the permission.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Display name of the permission.
        /// This can be used to show permission to the user.
        /// </summary>
        public LocalizableString DisplayName { get; private set; }

        /// <summary>
        /// A brief description for this permission.
        /// </summary>
        public LocalizableString Description { get; private set; }

        /// <summary>
        /// Is this permission granted by default.
        /// </summary>
        public bool IsGrantedByDefault { get; private set; }

        /// <summary>
        /// Creates a new Permission.
        /// </summary>
        /// <param name="name">Unique name of the permission</param>
        /// <param name="displayName">Display name of the permission</param>
        /// <param name="isGrantedByDefault">Is this permission granted by default</param>
        /// <param name="description">A brief description for this permission</param>
        public PermissionDefinition(string name, LocalizableString displayName, bool isGrantedByDefault = false, LocalizableString description = null)
        {
            Name = name;
            DisplayName = displayName;
            IsGrantedByDefault = isGrantedByDefault;
            Description = description;
        }
    }
}
