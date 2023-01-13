using MauiChatAppdeux.ViewModels;
using Plugin.Firebase.CloudMessaging;

namespace MauiChatAppdeux;

public partial class MainPage : ContentPage
{
	

	public MainPage()
	{
		InitializeComponent();
		BindingContext = new LoginViewModel(Navigation);
	}

    /*private async void OnCounterClicked(object sender, EventArgs e)
    {
        await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
        var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
        await DisplayAlert("FCM token", token, "OK");
    }*/
}

