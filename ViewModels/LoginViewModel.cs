using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Firebase.Auth;
using Firebase.RemoteConfig;
using GalaSoft.MvvmLight;
using MauiChatAppdeux.Models;
using MauiChatAppdeux.Services;
using MauiChatAppdeux.ViewModels.Base;
using MauiChatAppdeux;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;


namespace MauiChatAppdeux.ViewModels 
{
    internal class LoginViewModel : Base.ViewModelBase
    {
        private readonly ILoginService _loginService;
   

        public Command RegisterBtn { get; }
        public Command LoginBtn { get; }
        //public string UserName { get; private set; }
       // public string UserPassword { get; private set; }

       

        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;

        }

       

        public LoginViewModel()
        {
           // this._navigation = navigation;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginBtn = new Command(LoginBtnTappedAssync);
        }

        private async void LoginBtnTappedAssync(object obj)
        {
            await Shell.Current.GoToAsync("//profile/chatarea");
            /*UserName = UserName;
            UserPassword = UserPassword;*/
            /*
                        if (!string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(UserPassword))
                        {
                           /* var response = await _loginService.Authenticate(new LoginRequest
                            {
                                email = UserName,
                                password = UserPassword
                            });

                            if (!string.IsNullOrWhiteSpace(response.name))
                            {
                                var userDetails = new UserBasicInfo
                                {
                                    email = UserName,

                                };

                                if (Preferences.ContainsKey(nameof(App.UserDetails)))
                                {
                                    Preferences.Remove(nameof(App.UserDetails));
                                }

                                string userDetailStr = JsonConvert.SerializeObject(userDetails);
                                Preferences.Set(nameof(App.UserDetails), userDetailStr);
                                App.UserDetails = userDetails;*/
            // await Shell.Current.GoToAsync("ChatRooms");          //this._navigation.PushAsync(new ChatRooms());

            /* }
             else
             {

                     //    await AppShell.Current.DisplayAlert("Invalid User", "Incorrect", "OK");
             }*/

            /*}
            else
            {
                await Shell.Current.GoToAsync(nameof(ChatRooms));
                // await    .PushAsync(new ChatRooms());
            }*/



        }

        private async void RegisterBtnTappedAsync(object obj)
        {
            await Shell.Current.GoToAsync("//profile/register");


        }

      

    }
}
