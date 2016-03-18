using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hippi
{
    /// <summary>
    /// Response object format for HipChat Integration API
    /// </summary>
    public class ChatMessage
    {
        public string color = "black";
        public string message = "";
        public bool notify = false;
        public string message_format = "text";
    }
}
