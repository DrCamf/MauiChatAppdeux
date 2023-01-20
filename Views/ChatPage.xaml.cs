using MauiChatAppdeux.ViewModels;

namespace MauiChatAppdeux;

public partial class ChatPage : ContentPage {
	private int _id;
	public ChatPage(int id)
	{
		InitializeComponent();
		_id = id;
        BindingContext = new ChatViewModel(_id);
    }
}