using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiChatAppdeux.ViewModels
{
    internal class RegistrationViewModel
    {
        private INavigation _navigation;

        public Command RegisterUser { get;}

        public RegistrationViewModel(INavigation navigation) 
        {
            this._navigation = navigation;
            RegisterUser = new Command(RegisterUserTappedAsync);
        }

        private void RegisterUserTappedAsync(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
