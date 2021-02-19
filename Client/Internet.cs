using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Client
{
    internal static class Internet
    {
        public static Stream OpenResource(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            return stream;
        }

        public static MemoryStream ReadResource(Stream resource)
        {
            MemoryStream ms = new MemoryStream();
            byte[] buffer = new byte[1024 * 100];
            int r;
            while ((r = resource.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, r);
            }
            return ms;
        }

        public static void ReadResourceToFile(Stream resource, string filename)
        {
            FileStream file = File.Create(filename);
            byte[] buffer = new byte[1024 * 100];
            int r;
            while ((r = resource.Read(buffer, 0, buffer.Length)) > 0)
            {
                file.Write(buffer, 0, r);
            }
        }
    }
}
