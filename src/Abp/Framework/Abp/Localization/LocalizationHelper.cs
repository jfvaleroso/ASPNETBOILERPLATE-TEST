using System.Globalization;
using Abp.Dependency;
using Abp.Localization.Sources;

namespace Abp.Localization
{
    /// <summary>
    /// This static class is used to simplify getting localized strings.
    /// </summary>
    public static class LocalizationHelper
    {
        private static readonly ILocalizationSourceManager LocalizationSourceManager;

        static LocalizationHelper()
        {
            LocalizationSourceManager = IocHelper.Resolve<ILocalizationSourceManager>();
        }

        /// <summary>
        /// Gets a localized string in current language.
        /// </summary>
        /// <param name="sourceName">Name of the localization source</param>
        /// <param name="name">Key name to get localized string</param>
        /// <returns>Localized string</returns>
        public static string GetString(string sourceName, string name)
        {
            return LocalizationSourceManager.GetSource(sourceName).GetString(name);
        }

        /// <summary>
        /// Gets a localized string in current language.
        /// </summary>
        /// <param name="localizableString">LocalizableString object</param>
        /// <returns>Localized string</returns>
        public static string GetString(LocalizableString localizableString)
        {
            return GetString(localizableString.SourceName, localizableString.Name);
        }

        /// <summary>
        /// Gets a localized string in specified language.
        /// </summary>
        /// <param name="sourceName">Name of the localization source</param>
        /// <param name="name">Key name to get localized string</param>
        /// <param name="culture">culture</param>
        /// <returns>Localized string</returns>
        public static string GetString(string sourceName, string name, CultureInfo culture)
        {
            return LocalizationSourceManager.GetSource(sourceName).GetString(name, culture);
        }

        /// <summary>
        /// Gets a localized string in specified language.
        /// </summary>
        /// <param name="localizableString">LocalizableString object</param>
        /// <param name="culture">culture</param>
        /// <returns>Localized string</returns>
        public static string GetString(LocalizableString localizableString, CultureInfo culture)
        {
            return LocalizationSourceManager.GetSource(localizableString.SourceName).GetString(localizableString.Name, culture);
        }

        /// <summary>
        /// Gets a pre-registered localization source.
        /// </summary>
        public static ILocalizationSource GetSource(string name)
        {
            return LocalizationSourceManager.GetSource(name);
        }

        /// <summary>
        /// Registers a localization source.
        /// </summary>
        /// <typeparam name="T">Type of the localization source.</typeparam>
        public static void RegisterSource<T>() where T : ILocalizationSource
        {
            LocalizationSourceManager.RegisterSource(IocHelper.Resolve<T>());
        }
    }
}