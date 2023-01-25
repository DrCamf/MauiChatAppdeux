using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Firebase.Auth;
using Firebase.RemoteConfig;

using MauiChatAppdeux.Models;
using MauiChatAppdeux.Services;
using MauiChatAppdeux.ViewModels.Base;
using MauiChatAppdeux;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiChatAppdeux.ViewModels 
{
    public partial class LoginViewModel : ViewModelBase
    {
        private readonly ILoginService _loginService;
   

        public Command RegisterBtn { get; }
        public Command LoginCommand { get; }

       
        private string email;

        
        private string password;

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Password
        {
            get => password;    
            set => SetProperty(ref password, value);
        }
        


        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;

        }

       

        public LoginViewModel()
        {
           // this._navigation = navigation;
            RegisterBtn = new Command(RegisterBtnTappedAsync);
            LoginCommand = new Command(async () => await LoginCommandTappedAsync());
        }

       
        async Task LoginCommandTappedAsync()
        {
            if (!string.IsNullOrWhiteSpace(Email) && !string.IsNullOrWhiteSpace(Password))
            {
               try
               {
                    LoginRequest requestInfo = new LoginRequest();
                    requestInfo.Email = Email;
                    requestInfo.Password = Password;

                    var response = await _loginService.Authenticate(requestInfo);
                    if (response.Id > 0)
                    {

                        await Shell.Current.GoToAsync("//profile/chatarea");

                    } else
                    {
                        await AppShell.Current.DisplayAlert("Invalid User", "Incorrect", "OK");
                    }
                } catch (Exception ex)
                {
                    await AppShell.Current.DisplayAlert("Failure", ex.Message, "OK");
                }
                

                
               
            } else
            {
                await AppShell.Current.DisplayAlert("Invalid User", "No input", "OK");
            }

            
               
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
