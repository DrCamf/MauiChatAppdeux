using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiChatAppdeux.Models
{
    public class SendMessage
    {
        public int chatarea_id { get; set; }
        public int user_id { get; set; }

        public string chattext { get; set; }
        public string date { get; set; }
    }
}
