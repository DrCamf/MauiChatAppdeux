using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiChatAppdeux.Models
{
    public class SendMessage
    {
        public string chattext { get; set; }
        public int user_id { get; set; }
        public int chatarea_id { get; set; }
             
        public string time { get; set; }
    }
}
