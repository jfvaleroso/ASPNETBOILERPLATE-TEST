﻿using System.IO;
using System.Linq;
using System.Reflection;
using Abp.Dependency;
using Abp.Localization.Dictionaries.Xml;

namespace Abp.Localization.Sources.Xml
{
    /// <summary>
    /// XML based localization source.
    /// It uses XML files to read localized strings.
    /// </summary>
    public abstract class XmlLocalizationSource : DictionaryBasedLocalizationSource, ISingletonDependency
    {
        internal static string RootDirectoryOfApplication { get; set; } //TODO: Find a better way of passing root directory

        /// <summary>
        /// Gets directory
        /// </summary>
        public string DirectoryPath { get; private set; }

        static XmlLocalizationSource()
        {
            RootDirectoryOfApplication = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// Creates an Xml based localization source.
        /// </summary>
        /// <param name="name">Unique Name of the source</param>
        /// <param name="directory">Directory path</param>
        protected XmlLocalizationSource(string name, string directory)
            : base(name)
        {
            if (!Path.IsPathRooted(directory))
            {
                directory = Path.Combine(RootDirectoryOfApplication, directory);
            }

            DirectoryPath = directory;
            Initialize();
        }

        private void Initialize()
        {
            var files = Directory.GetFiles(DirectoryPath, "*.xml", SearchOption.TopDirectoryOnly);
            var defaultLangFile = files.FirstOrDefault(f => f.EndsWith(Name + ".xml"));
            if (defaultLangFile == null)
            {
                throw new AbpException("Can not find default localization file for source " + Name + ". A source must contain a source-name.xml file as default localization.");
            }

            AddDictionary(XmlLocalizationDictionary.BuildFomFile(defaultLangFile), true);
            foreach (var file in files.Where(f => f != defaultLangFile))
            {
                AddDictionary(XmlLocalizationDictionary.BuildFomFile(file));
            }
        }
    }
}
