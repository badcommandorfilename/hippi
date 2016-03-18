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
        public string color { get; set; } = "black";
        public string message { get; set; } = "";
        public bool notify { get; set; } = false;
        public string message_format { get; set; } = "text";
    }
}
