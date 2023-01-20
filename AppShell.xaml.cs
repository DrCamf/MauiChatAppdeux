namespace MauiChatAppdeux;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(ChatRooms), typeof(ChatRooms));
        Routing.RegisterRoute(nameof(ChatPage), typeof(ChatPage));
    }
}
