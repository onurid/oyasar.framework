using System.Linq;
#if NET451
using System.Configuration;
#endif
using System.IO;
using System;

namespace OYASAR.Framework.Core.Helper
{
    public static class DomainHelper
    {
        public static readonly string DomainAddr;
        public static readonly string BaseDirForDll;

        private const char splitKey = '/';

        static DomainHelper()
        {

#if NETSTANDARD1_3
            DomainAddr = AppContext.BaseDirectory;
            BaseDirForDll = AppContext.BaseDirectory;
#endif
#if NET451

            DomainAddr = ConfigurationManager.AppSettings["DomainAddr"];
            BaseDirForDll = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "\\bin\\";

#endif
        }

        public static string ToTakeFileFromUrl(this string str)
        {
            return str.Split(splitKey).Last();
        }

        public static string ToNewUrlForFile(this string str)
        {
            return $"{DomainAddr}/{str.ToTakeFileFromUrl()}";
        }
    }
}
