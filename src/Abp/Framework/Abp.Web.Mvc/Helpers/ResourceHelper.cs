﻿using System;
using System.Collections.Concurrent;
using System.IO;
using System.Web;
using System.Web.Mvc;
using Abp.Logging;

namespace Abp.Web.Mvc.Helpers
{
    /// <summary>
    /// TODO: What if resource changes? How to update cache?
    /// </summary>
    public static class ResourceHelper
    {
        private static readonly ConcurrentDictionary<string, string> Cache;
        private static readonly object SyncObj = new object();

        static ResourceHelper()
        {
            Cache = new ConcurrentDictionary<string, string>();
        }

        /// <summary>
        /// Includes a script to the page with versioning.
        /// </summary>
        /// <param name="html">Reference to the HtmlHelper object</param>
        /// <param name="url">URL of the script file</param>
        public static IHtmlString IncludeScript(this HtmlHelper html, string url)
        {
            return html.Raw("<script src=\"" + GetResourcePathWithVersioning(url) + "\" type=\"text/javascript\"></script>");
        }

        /// <summary>
        /// Includes a style to the page with versioning.
        /// </summary>
        /// <param name="html">Reference to the HtmlHelper object</param>
        /// <param name="url">URL of the style file</param>
        public static IHtmlString IncludeStyle(this HtmlHelper html, string url)
        {
            return html.Raw("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + GetResourcePathWithVersioning(url) + "\" />");
        }

        private static string GetResourcePathWithVersioning(string path)
        {
            if (Cache.ContainsKey(path))
            {
                return Cache[path];
            }

            lock (SyncObj)
            {
                if (Cache.ContainsKey(path))
                {
                    return Cache[path];
                }

                string result;
                try
                {
                    var fullPath = HttpContext.Current.Server.MapPath(path.Replace("/", "\\"));
                    var fileVersion = new FileInfo(fullPath).LastWriteTime.Ticks;

                    result = VirtualPathUtility.ToAbsolute(path) + "?v=" + fileVersion;
                }
                catch (Exception ex)
                {
                    LogHelper.Logger.Error("Can not find file for: " + path + "! " + ex.Message);
                    result = path;
                }

                Cache[path] = result;
                return result;
            }
        }
    }
}
