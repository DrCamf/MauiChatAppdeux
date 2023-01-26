using MauiChatAppdeux.Models;
using MauiChatAppdeux.ViewModels;


namespace MauiChatAppdeux;

public partial class App : Application
{
    public static UserBasicInfo UserDetails;
    public static Area ChosenArea;
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
    }
}
