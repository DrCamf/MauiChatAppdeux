using MauiChatAppdeux.ViewModels;

namespace MauiChatAppdeux;

public partial class ChatPage : ContentPage {

	public ChatPage()
	{
		InitializeComponent();
		
        BindingContext = new ChatViewModel();
    }
}