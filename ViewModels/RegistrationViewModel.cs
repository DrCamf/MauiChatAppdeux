


using System.ComponentModel;

using Firebase.Auth;

using Plugin.Firebase.Auth;

namespace MauiChatAppdeux.ViewModels
{
    internal class RegistrationViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;
        public string webApiKey = "";
        private string email;
        private string password;

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


        public Command RegisterUser { get;}

        public RegistrationViewModel(INavigation navigation) 
        {
            this._navigation = navigation;
            //RegisterUser = new Command(RegisterUserTappedAsync);
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
