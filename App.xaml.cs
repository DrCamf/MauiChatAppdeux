using MauiChatAppdeux.ViewModels;
using MauiChatAppdeux.Views;

namespace MauiChatAppdeux;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new MainPage());
	}
}
