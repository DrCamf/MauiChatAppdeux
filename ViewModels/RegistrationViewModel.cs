


using System.ComponentModel;
using Firebase.Auth;
using GalaSoft.MvvmLight;
using MauiChatAppdeux.Models;
using MauiChatAppdeux.Services;
using Plugin.Firebase.Auth;

namespace MauiChatAppdeux.ViewModels
{
    internal class RegistrationViewModel : ViewModelBase
    {
       
        public string webApiKey = "";
        private string email;
        private string password;
        private string name;
        private string picturepath;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                RaisePropertyChanged("Email");
            }
        }

        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public string Password
        {
            get => password; set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }
        public string Name
        {
            get => name; set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        public string PicturePath
        {
            get => picturepath; set
            {
                picturepath = value;
                RaisePropertyChanged("PicturePath");
            }
        }


        public Command RegisterUser { get;}

        public RegistrationViewModel() 
        {
            
            RegisterUser = new Command(async () => await RegisterUserTappedAsync());
        }

        private async Task RegisterUserTappedAsync()
        { 

            RegisterInfo info = new RegisterInfo();
            info.email = Email;
            info.pass = Password;
            info.name = Name;
            info.image = PicturePath;

            bool response = RegisterService.Instance.CreateUser(info);
            if (response)
            {
                await AppShell.Current.DisplayAlert("User Created", "Succes", "OK");
                await Shell.Current.GoToAsync("//profile/main");
            } else
            {
                await AppShell.Current.DisplayAlert("User Created", "No Succes", "OK");
            }
        }

        /* private async void RegisterUserTappedAsync(object obj)
          {
              CrossFirebaseAuth mAuth;
              try
              {


                  var result = await CrossFirebaseAuth.Current.Instance.CreateUserWithEmailAndPasswordAsync(email, password);         //Instance.CreateUserWithEmailAndPasswordAsync();

                  var authProvider = FirebaseAuth.GetInstance(new FirebaseConfig(webApiKey));
                  var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Email, Password);
                  string token = auth.FirebaseToken;
                  if (token != null)
                      await App.Current.MainPage.DisplayAlert("Alert", "User Registered successfully", "OK");
                  await this._navigation.PopAsync();
              }
              catch (Exception ex)
              {
                  await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
                  throw;
             }
          }*/
    }
}
