using MauiChatAppdeux.ViewModels;

namespace MauiChatAppdeux;

public partial class ChatPage : ContentPage {

	public ChatPage(ChatViewModel viewModel)
	{
		InitializeComponent();
		
        BindingContext = viewModel;
    }
}