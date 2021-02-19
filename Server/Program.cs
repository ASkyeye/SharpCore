using SharpCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Server
{
    class Program
    {

        static SharpServer server;

        static void Main(string[] args)
        {
            // to do
            Console.WriteLine("Listening.. ");
            server.Listen(IPAddress.Any, 0);

            while ( true )
            {
                // SharpClient client = server.Accept();
            }
        }
    }
}
