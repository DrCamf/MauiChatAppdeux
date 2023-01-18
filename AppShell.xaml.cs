namespace MauiChatAppdeux;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("ChatRooms", typeof(ChatRooms));
    }
}
