using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCampGHPlugin.Utils
{
    public static class CustomPluginProperties
    {
        //public static string Version
        //{
        //    get
        //    {
        //        return MAJOR_VERSION + "." + MINOR_VERSION + "." + PATCH_VERSION;
        //    }
        //}

        /// <summary>
        /// Current plugin version.
        /// </summary>
        public static string Version => MAJOR_VERSION + "." + MINOR_VERSION + "." + PATCH_VERSION;

        public static readonly int MAJOR_VERSION = 0;
        public static readonly int MINOR_VERSION = 1;
        public static readonly int PATCH_VERSION = 0;

    }
}
