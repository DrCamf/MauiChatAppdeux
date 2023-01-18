

using MauiChatAppdeux.ViewModels;

namespace MauiChatAppdeux;

public partial class ChatRooms : ContentPage
{
    

    public ChatRooms()
	{
		InitializeComponent();
        BindingContext = new ChatRoomsViewModel(Navigation);
    }
}