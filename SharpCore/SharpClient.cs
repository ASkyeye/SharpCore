using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace SharpCore
{
    public class SharpClient
    {
        private Socket socket;
        private NetworkStream stream;
        private BinaryReader reader;
        private BinaryWriter  writer;
        public bool Connected { get => socket.Connected ;  }
        public void Connect(string host, ushort port) { 
            socket.Connect(host, port);
            stream = new NetworkStream(socket);
            reader = new BinaryReader(stream);
            writer = new BinaryWriter(stream);
        }
        public string  ReceiveMessage() => reader.ReadString();
        public void SendMessage(string message) => writer.Write(message);
    }
}
