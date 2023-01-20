using MauiChatAppdeux.ViewModels;

namespace MauiChatAppdeux.Views;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}