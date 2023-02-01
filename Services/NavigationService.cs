using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiChatAppdeux.Services
{
    public class NavigationService : INavigationService
    {
        readonly IServiceProvider _services;
        protected INavigation Navigation
        {
            get
            {
                INavigation? navigation = Application.Current?.MainPage?.Navigation;
                if (navigation is not null)
                    return navigation;
                else
                {
                    //This is not good!
                    if (Debugger.IsAttached)
                        Debugger.Break();
                    throw new Exception();
                }
            }
        }

        public string CurrentPageKey => throw new NotImplementedException();

        public NavigationService(IServiceProvider services)
            => _services = services;
        public Task NavigateToSecondPage()
        {
            var page = _services.GetService<Chat1Page>();
            if (page is not null)
                return Navigation.PushAsync(page, true);
            throw new InvalidOperationException($"Unable to resolve type Chat Page");
        }

        public async void GoBack()
        {
            await Shell.Current.GoToAsync("//middle/chatarea");

            throw new NotImplementedException();
        }

        public void NavigateTo(string pageKey)
        {
            throw new NotImplementedException();
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
