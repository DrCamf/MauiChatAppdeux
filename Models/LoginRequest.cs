using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiChatAppdeux.Models
{
    public class LoginRequest
    {
        public int Id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
