using MauiChatAppdeux.ViewModels;

namespace MauiChatAppdeux;

public partial class Chat4Page : ContentPage
{
	public Chat4Page()
	{
		InitializeComponent();
        BindingContext = new ChatViewModel(4);
    }
}