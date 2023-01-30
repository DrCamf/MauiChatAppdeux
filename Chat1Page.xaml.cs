using MauiChatAppdeux.ViewModels;

namespace MauiChatAppdeux;

public partial class Chat1Page : ContentPage
{
	public Chat1Page()
	{
		InitializeComponent();
        BindingContext = new ChatViewModel(1);
    }
}