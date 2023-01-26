using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




using MauiChatAppdeux.Models;
using MauiChatAppdeux.Services;
using MauiChatAppdeux.ViewModels.Base;
using MauiChatAppdeux;
using Newtonsoft.Json;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestSharp;

namespace MauiChatAppdeux.ViewModels 
{
    public partial class LoginViewModel : ViewModelBase
    {
        private readonly ILoginService _loginService;
        private LoginService loginService;

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
                 
                    User loginuser = new User();
                    UserBasicInfo userinfo = new UserBasicInfo();
                    string encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(requestInfo.Email + ":" + requestInfo.Password));

                    var url = "https://mauichat.elthoro.dk/basic.php";


                    using (var client = new RestClient(url))
                    {
                        var request = new RestRequest(url, Method.Get);
                        request.AddHeader("Authorization", "Basic " + encoded);
                        var body = @"";
                        request.AddParameter("application/json", body, ParameterType.RequestBody);
                        RestResponse response = await client.ExecuteAsync(request);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {

                            var json = response.Content.ToString();

                            loginuser = JsonConvert.DeserializeObject<User>(json);
                            userinfo.id = loginuser.id;
                            userinfo.name = loginuser.name;
                            userinfo.email = loginuser.email;
                            userinfo.image = loginuser.image;


                            App.UserDetails = userinfo;

                            if (Preferences.ContainsKey(nameof(App.UserDetails)))
                            {
                                Preferences.Remove(nameof(App.UserDetails));
                            }

                            string userDetailStr = JsonConvert.SerializeObject(userinfo);
                            Preferences.Set(nameof(App.UserDetails), userDetailStr);
                            App.UserDetails = userinfo;

                            //await AppShell.Current.DisplayAlert("valid User", "correct", "OK");
                            await Shell.Current.GoToAsync("//profile/chatarea");
                        }
                        else
                        {
                            await AppShell.Current.DisplayAlert("Invalid User", "Incorrect", "OK");
                        }
                    }
                        // response = await loginService.Authenticate(requestInfo);

                   
                } catch (Exception ex)
                {
                    await AppShell.Current.DisplayAlert("Failure", ex.Message, "OK");
                }
     
            } else
            {
                //await Shell.Current.GoToAsync("//profile/chatarea");
                await AppShell.Current.DisplayAlert("Invalid User", "No input", "OK");
            }

        }

        private async void RegisterBtnTappedAsync(object obj)
        {
            await Shell.Current.GoToAsync("//profile/register");


        }

      

    }
}
