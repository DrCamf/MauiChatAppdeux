using MauiChatAppdeux.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiChatAppdeux.Services
{
    public interface ILoginService
    {
        Task<User> Authenticate(LoginRequest loginRequest);
    }
}
