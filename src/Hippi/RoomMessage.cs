using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hippi
{
    public class From
    {
        public Int64 id { get; set; }
        public Dictionary<string, string> links { get; set; }
        public string mention_name { get; set; }
        public string name { get; set; }
        public string version { get; set; }
    }

    public class Message
    {
        public string date { get; set; }
        public From from { get; set; }
        public string id { get; set; }
        public List<object> mentions { get; set; }
        public string message { get; set; }
        public string type { get; set; }
    }

    public class Room
    {
        public Int64 id { get; set; }
        public bool is_archived { get; set; }
        public Dictionary<string,string> links { get; set; }
        public string name { get; set; }
        public string privacy { get; set; }
        public string version { get; set; }
    }

    public class Item
    {
        public Message message { get; set; }
        public Room room { get; set; }
    }

    /// <summary>
    /// Request object format for Integrations API
    /// </summary>
    public class RoomMessage
    {
        public string @event { get; set; }
        public Item item { get; set; }
        public string oauth_client_id { get; set; }
        public Int64 webhook_id { get; set; }
    }

}
