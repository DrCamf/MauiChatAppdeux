﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace MauiChatAppdeux.ViewModels
{
    internal class LoginViewModel
    {
        public string webApiKey = "";
        private INavigation _navigation;

        public Command RegisterBtn { get; }
        public Command LoginBtn { get; }

        public LoginViewModel(INavigation navigation)
        {
            this._navigation = navigation;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAssync);
        }

        private async void LoginBtnTappedAssync(object obj)
        {
            await this._navigation.PushAsync(new Dashboard());
        }

        private async void RegisterBtnTappedAsync(object obj)
        {
            await this._navigation.PushAsync(new RegisterPage());
        }

      
       
    }
}