using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpCore
{
    public enum  SharpMessageType : byte
    {
        /// <summary>
        /// No message
        /// </summary>
        None,
        /// <summary>
        /// Download and execute an image
        /// </summary>
        DownloadExecute,
        /// <summary>
        /// Tells the server that everything is ok
        /// </summary>
        OKServer,
        /// <summary>
        /// Tells the client that everything is ok
        /// </summary>
        OKClient,
    }
}
