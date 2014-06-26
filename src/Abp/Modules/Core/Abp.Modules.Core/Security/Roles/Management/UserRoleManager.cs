﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Caching;
using Abp.Runtime.Caching;

namespace Abp.Security.Roles.Management
{
    public class UserRoleManager : IUserRoleManager
    {
        private readonly IUserRoleRepository _userRoleRepository;

        private readonly ThreadSafeObjectCache<UserRoleInfo> _userInfoCache;

        public UserRoleManager(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
            _userInfoCache = new ThreadSafeObjectCache<UserRoleInfo>(new MemoryCache(GetType().Name), TimeSpan.FromMinutes(30)); //TODO: Get constant from somewhere else.
        }

        public IReadOnlyList<string> GetRolesOfUser(string userId)
        {
            var roleInfo = _userInfoCache.Get(
                userId,
                () => new UserRoleInfo
                      {
                          UserId = Convert.ToInt32(userId),
                          Roles = _userRoleRepository.Query(q => q.Where(ur => ur.User.Id == Convert.ToInt32(userId)).Select(ur => ur.Role.Name).ToList())
                      });

            return roleInfo.Roles.ToImmutableList();
        }

        private class UserRoleInfo
        {
            public int UserId { get; set; }

            public List<string> Roles { get; set; }
        }
    }
}