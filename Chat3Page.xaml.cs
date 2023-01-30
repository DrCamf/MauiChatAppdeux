using MauiChatAppdeux.ViewModels;

namespace MauiChatAppdeux;

public partial class Chat3Page : ContentPage
{
	public Chat3Page()
	{
		InitializeComponent();
        BindingContext = new ChatViewModel(3);
    }
}