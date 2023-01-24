using MauiChatAppdeux.ViewModels;

namespace MauiChatAppdeux;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}