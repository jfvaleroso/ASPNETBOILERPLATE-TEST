﻿using System;
using Abp.Startup;

namespace Abp.Modules
{
    /// <summary>
    /// Base class that can be inherited to easily implement <see cref="IAbpModule"/>.
    /// </summary>
    public abstract class AbpModule : IAbpModule
    {
        /// <summary>
        /// Gets all depended modules for this module.
        /// </summary>
        /// <returns>List of depended modules.</returns>
        public virtual Type[] GetDependedModules()
        {
            return new Type[] {};
        } 

        /// <summary>
        /// What can be done in this method:
        /// - Make things those must be done before dependency registers.
        /// </summary>
        /// <param name="initializationContext">Initialization context</param>
        public virtual void PreInitialize(IAbpInitializationContext initializationContext)
        {

        }

        /// <summary>
        /// What can be done in this method:
        /// - Register dependency installers and components.
        /// </summary>
        /// <param name="initializationContext">Initialization context</param>
        public virtual void Initialize(IAbpInitializationContext initializationContext)
        {

        }

        /// <summary>
        /// What can be done in this method:
        /// - Make things those must be done after dependency registers.
        /// </summary>
        /// <param name="initializationContext">Initialization context</param>
        public virtual void PostInitialize(IAbpInitializationContext initializationContext)
        {
            
        }

        /// <summary>
        /// This method is called when the application is being shutdown.
        /// </summary>
        public virtual void Shutdown()
        {
            
        }
    }
}
