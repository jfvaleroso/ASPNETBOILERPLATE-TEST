﻿using System.Globalization;

namespace Abp.Web.Localization
{
    /// <summary>
    /// Define interface to get localization javascript.
    /// </summary>
    public interface ILocalizationScriptManager
    {
        /// <summary>
        /// Gets Javascript that contains all localization informations in current culture.
        /// </summary>
        string GetLocalizationScript();

        /// <summary>
        /// Gets Javascript that contains all localization informations in given culture.
        /// </summary>
        /// <param name="cultureInfo">Culture to get script</param>
        string GetLocalizationScript(CultureInfo cultureInfo);
    }
}