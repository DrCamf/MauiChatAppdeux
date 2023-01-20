using MauiChatAppdeux.Models;
using MauiChatAppdeux.ViewModels;
using MauiChatAppdeux.Views;

namespace MauiChatAppdeux;

public partial class App : Application
{
    public static UserBasicInfo UserDetails;
    public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new HomeView());
	}
}
