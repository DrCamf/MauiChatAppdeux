using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiChatAppdeux.ViewModels
{
    internal class ChatRoomsViewModel
    {
        private INavigation _navigation;

        public ChatRoomsViewModel(INavigation navigation)
        {
            this._navigation = navigation;
           
        }
    }
}
